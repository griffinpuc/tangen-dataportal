using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.IO.Compression;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Newtonsoft.Json;
using Portal.Models;
using System.Linq;
using System.Text;
using Portal.Hubs;
using System.IO;
using System;
using System.Diagnostics;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {

        /* =========================================
           =         TDP: HOME CONTROLLERS         = 
           =                                       =
           =========================================
           
            [] MAIN HANDLERS
            [] PARTIAL UPDATES
            [] SORTING CALLS
            [] QUERY HANDLERS
            [] DATA MANIPULATION / LOGICAL
            [] DOWNLOAD HANDLERS
            [] OTHER
             
        */



        /* Get database connection context for querying */
        private contextDatabase _context;
        private readonly IHubContext<LogHub> _hubContext;

        public HomeController(contextDatabase context, IHubContext<LogHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }



        /* ========================================= */
        /* DEV TOOLS (ONLY FOR DEVELOPMENT RELEASES) */
        /* ========================================= */

        public IActionResult dev()
        {
            return View();
        }

        public void vanq()
        {
            _context.vanquish();
        }

        public void forcefeed(int amount)
        {
            HttpContext.Session.SetInt32("DEV_totalamount", amount);
            HttpContext.Session.SetInt32("DEV_currentamount", 1);
            HttpContext.Session.SetString("DEV_timestarted", DateTime.Now.ToString());
            HttpContext.Session.SetString("DEV_timeended", "...");

            Random random = new Random();

            for (int i=1; i<=amount; i++)
            {

                modelDataResult data = new modelDataResult()
                {
                    uniqueID = random.Next(0, 999999).ToString(),
                    downloadDateTime = Convert.ToString(System.DateTime.Now)
                };

                _context.addEntry(data);
                HttpContext.Session.SetInt32("DEV_currentamount", i);
            }

            HttpContext.Session.SetString("DEV_timeended", DateTime.Now.ToString());
            //HttpContext.Session.SetInt32("DEV_currentamount", 0);

        }

        public IActionResult updatefeed()
        {
            modelPackage pckg = new modelPackage()
            {
                progress2 = HttpContext.Session.GetInt32("DEV_currentamount") ?? 1,
                count = HttpContext.Session.GetInt32("DEV_totalamount") ?? 1,
                elapsed = HttpContext.Session.GetString("DEV_timestarted"),
                endtime = HttpContext.Session.GetString("DEV_timeended")
            };

            return PartialView("_PartialDev", pckg);
        }

        public void populatecred()
        {
            modelCredentials cred = new modelCredentials()
            {
                email = "admin@admin",
                password = _context.computeHash("alpine"),
                sysadmin = true
            };

            modelInstruments ins = new modelInstruments()
            {
                name = "NUGGET_TEST",
                localAddress = "192.168.6.23:5000",
                status = "OFFLINE"
            };

            _context.addEntry(cred);
            _context.addEntry(ins);
        }

        public void populateset()
        {
            forcefeed(10);
        }



        /* ========================================= */
        /*               MAIN HANDLERS               */
        /* ========================================= */

        /* Main index view*/
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("load_no", 1);

            modelPackage pckg = new modelPackage();
            pckg.instruments = _context.returnAllInstruments();

            HttpContext.Session.SetInt32("lastAmount", _context.resultsCount());
            HttpContext.Session.SetString("progress", "No progress to display");
            HttpContext.Session.SetString("datefilter", "off-x-x");

            return View(pckg);
        }

        /* Admin portal view */
        public IActionResult adminPortal()
        {
            if (HttpContext.Session.GetString("permissions") == "admin")
            {
                modelPackage pckg = new modelPackage()
                {
                    issys = false
                };

                if (HttpContext.Session.GetString("permlevel") == "sysadmin")
                {
                    pckg.issys = true;
                }


                return View(pckg);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /* Update data model */
        public IActionResult updateModel()
        {
            HttpContext.Session.SetInt32("load_no", 1);
            HttpContext.Session.SetString("lastsearch", "none");
            HttpContext.Session.SetInt32("lastAmount", _context.resultsCount());
            HttpContext.Session.SetString("datefilter", "off-x-x");

            modelPackage pckg = new modelPackage()
            {
                dataresults = _context.allResultsNewSort(1),
                total = _context.resultsCount(),
                count = _context.resultsCount()
            };

            return PartialView("_PartialData", pckg);
        }

        /* Login handler */
        [HttpPost]
        public IActionResult loginHandler(string email, string password)
        {
            string unmae = email;
            string pass = password;

            int returned = _context.secureLogin(email, password);

            if (returned == 1)
            {
                HttpContext.Session.SetString("permissions", "admin");
                HttpContext.Session.SetString("permlevel", "NONsysadmin");
            }
            else if (returned == 2)
            {
                HttpContext.Session.SetString("permissions", "admin");
                HttpContext.Session.SetString("permlevel", "sysadmin");
            }
            else
            {
                return RedirectToAction("index", "home");
            }

            return RedirectToAction("adminportal", "home");
        }

        /* Async SIGNALR log handler */
        public async Task sendLog(string message)
        {
            await _hubContext.Clients.All.SendAsync("rm", message);
        }

        /* Async SIGNALR log handler */
        public async Task updateProgressBar(double amount)
        {
            await _hubContext.Clients.All.SendAsync("updateprogress", Math.Round(amount));
        }


        /* ========================================= */
        /*              PARTIAL UPDATES              */
        /* ========================================= */

        /* Update data model */
        public IActionResult updateButton()
        {
            int i = _context.allResultsNewSort(HttpContext.Session.GetInt32("load_no") ?? 1).Length;
            int x = HttpContext.Session.GetInt32("lastAmount") ?? 1;

            int ret = ((_context.resultsCount()) - (HttpContext.Session.GetInt32("lastAmount") ?? 1));

            return PartialView("_PartialButton", ret);
        }

        /* Update connections model */
        public IActionResult updateConnections()
        {

            modelInstruments[] instrumentsArray = _context.returnAllInstruments().Where(x => x.status.Equals("IDLE")).ToArray();

            return PartialView("_PartialIndexInstruments", new modelPackage()
            {
                connectedInstruments = instrumentsArray.Length,
                totalInstruments = _context.returnAllInstruments().Length,
                instruments = _context.returnAllInstruments(),
                count = _context.returnTableCountTrack()
            });
        }

        /* Update database management */
        public IActionResult updateDatabasePanel()
        {
            modelPackage pckg = new modelPackage()
            {
                count = _context.resultsCount(),
                counttrack = _context.returnTableCountTrack(),
                totalInstruments = _context.returnAllInstruments().Count(),
                countusers = _context.returnAllAccounts().Count()
            };

            return PartialView("_PartialDBManage", pckg);
        }

        /* Update adminpanel:instruments model */
        public IActionResult updateInstruments()
        {
            modelPackage pckg = new modelPackage() { instruments = _context.returnAllInstruments() };

            return PartialView("_PartialInstruments", pckg);
        }

        /* Update adminpanel:users model */
        public IActionResult updateUsers()
        {
            modelPackage pckg = new modelPackage() { credentials = _context.returnAllAccounts() };
            return PartialView("_PartialAccount", pckg);
        }

        /* Update progress */
        public IActionResult updateProgress()
        {
            modelPackage pckg = new modelPackage()
            {
                progress = HttpContext.Session.GetString("progress")
            };

            return PartialView("_PartialProgress", pckg);

        }



        /* ========================================= */
        /*               SORTING CALLS               */
        /* ========================================= */

        /* Load more results */
        public IActionResult loadMore()
        {
            HttpContext.Session.SetInt32("load_no", (HttpContext.Session.GetInt32("load_no") ?? 1) + 1);
            int loadNo = HttpContext.Session.GetInt32("load_no") ?? 1;
            int loaded = _context.resultsCount();

            bool searchFlag, dateFlag;
            searchFlag = dateFlag = false;

            string searchFlagTerm, dateFlagStart, dateFlagEnd;
            searchFlagTerm = dateFlagStart = dateFlagEnd = string.Empty;

            modelDataResult[] retval;

            if (!HttpContext.Session.GetString("lastsearch").Equals("none"))
            {
                searchFlag = true;
                searchFlagTerm = HttpContext.Session.GetString("lastsearch");
            }
            if (HttpContext.Session.GetString("datefilter").Split("-")[0].Equals("on"))
            {
                dateFlag = true;
                dateFlagStart = HttpContext.Session.GetString("datefilter").Split("-")[1];
                dateFlagEnd = HttpContext.Session.GetString("datefilter").Split("-")[2];
            }

            if (searchFlag && dateFlag)
            {
                retval = _context.getFromSearch
                    (
                        searchFlagTerm,
                        loadNo,
                        _context.returnallabsoluteResultsTimeframe(Convert.ToDateTime(dateFlagStart), Convert.ToDateTime(dateFlagEnd), loadNo)
                    );
            }
            else if (searchFlag)
            {
                retval = _context.getFromSearch(searchFlagTerm, loadNo, _context.allResults());
            }
            else if (dateFlag)
            {
                retval = _context.returnallabsoluteResultsTimeframe(Convert.ToDateTime(dateFlagStart), Convert.ToDateTime(dateFlagEnd), loadNo);
            }
            else
            {
                retval = _context.allResultsNewSort(loadNo);
            }

            modelPackage pckg = new modelPackage()
            {
                dataresults = retval,
                total = retval.Length,
                count = loaded

            };

            return PartialView("_PartialData", pckg);
        }

        /* Update dates */
        public IActionResult UpdateDates(string dates)
        {
            var splitted = dates.Split(",");
            var sD = splitted[0].Split(" ");
            var eD = splitted[1].Split(" ");
            string startDateFormatted = sD[0] + " " + sD[1] + " " + sD[2] + " " + sD[3] + " " + sD[4];
            string endDateFormatted = eD[0] + " " + eD[1] + " " + eD[2] + " " + eD[3] + " " + eD[4];

            DateTime startDate = Convert.ToDateTime(startDateFormatted);
            DateTime endDate = Convert.ToDateTime(endDateFormatted);

            modelDataResult[] results;
            int loadNo = HttpContext.Session.GetInt32("load_no") ?? 1;
            int count;

            if (!HttpContext.Session.GetString("lastsearch").Equals("none"))
            {
                string x = HttpContext.Session.GetString("lastsearch");
                results = _context.getFromSearch
                    (
                        HttpContext.Session.GetString("lastsearch"),
                        loadNo,
                        _context.returnallResultsTimeframeAll(startDate, endDate)
                    );

                count = _context.getFromSearch
                    (
                        HttpContext.Session.GetString("lastsearch"),
                        loadNo,
                        _context.returnallResultsTimeframeAll(startDate, endDate)
                    ).Length;

            }
            else
            {
                results = _context.returnallResultsTimeframe(startDate, endDate, HttpContext.Session.GetInt32("load_no") ?? 1);

                count = _context.returnallResultsTimeframeAll(startDate, endDate).Length;
            }

            modelPackage pckg = new modelPackage()
            {
                dataresults = results,
                total = count,
            };

            HttpContext.Session.SetString("datefilter", "on-" + startDateFormatted + "-" + endDateFormatted);

            return PartialView("_PartialData", pckg);
        }

        /* Sort results ny new */
        public IActionResult sortNew()
        {
            return PartialView("_PartialData", _context.allResultsNewSort(HttpContext.Session.GetInt32("load_no") ?? 1));;
        }

        /* Sort results by old */
        public IActionResult sortOld()
        {
            return PartialView("_PartialData", _context.allResultsNewSort(HttpContext.Session.GetInt32("load_no") ?? 1));
        }

        /* Update data model on search term enter */
        public IActionResult updateFromSearch(string term)
        {
            modelDataResult[] retval;
            int num = HttpContext.Session.GetInt32("load_no") ?? 1;
            int loaded = _context.resultsCount();
            int count = 0;

            if (term == null)
            {
                retval = _context.allResultsNewSort(HttpContext.Session.GetInt32("load_no") ?? 1);
            }

            else
            {
                if (HttpContext.Session.GetString("datefilter").Split("-")[0].Equals("on"))
                {
                    DateTime dateStart = Convert.ToDateTime(HttpContext.Session.GetString("datefilter").Split("-")[1]);
                    DateTime dateEnd = Convert.ToDateTime(HttpContext.Session.GetString("datefilter").Split("-")[2]);

                    retval = _context.getFromSearch(term, num, _context.returnallabsoluteResultsTimeframe(dateStart, dateEnd, num));
                    count = _context.getFromSearchAll(term, _context.returnallResultsTimeframeAll(dateStart, dateEnd)).Length;
                }
                else
                {
                    retval = _context.getFromSearch(term, num, null).ToList().Take(15 * num).ToArray();
                    count = _context.getFromSearchAll(term, _context.allResults()).Length;
                }

            }

            modelPackage pckg = new modelPackage()
            {
                dataresults = retval,
                total = count,
                count = loaded
            };

            if (term == null)
            {
                HttpContext.Session.SetString("lastsearch", "none");
            }
            else
            {
                HttpContext.Session.SetString("lastsearch", term);
            }

            return PartialView("_PartialData", pckg);
        }



        /* ========================================= */
        /*               QUERY HANDLERS              */
        /* ========================================= */

        /* Add new instrument */
        public IActionResult addInstrument(string instrumentname, string instrumentaddress)
        {
            if (!(instrumentaddress == null || instrumentname == null))
            {
                modelInstruments newinstrument = new modelInstruments()
                {
                    name = instrumentname,
                    localAddress = instrumentaddress,
                    status = "OFFLINE"
                };

                _context.addEntry(newinstrument);
            }

            return PartialView("_PartialInstruments");
        }

        /* Remove instrument */
        public void removeInstrument(int instrumentID)
        {
            _context.removeEntry(_context.returnInstrumentFromID(instrumentID));
        }

        /* Remove user */
        public void removeUser(int userID)
        {
            _context.removeEntry(_context.returnUserFromID(userID));
        }

        /* Add new tag to database */
        public IActionResult addNewTag(string name)
        {
            var random = new Random();
            modelTag newtag = new modelTag();
            newtag.name = name;
            newtag.color = String.Format("#{0:X6}", random.Next(0x1000000));

            _context.addEntry(newtag);

            modelPackage pckg = new modelPackage();

            return PartialView("_PartialTagDrop", pckg);
        }

        /* Add new user */
        public IActionResult addUser(string email, string password, bool sysadmin)
        {
            modelCredentials newcredential = new modelCredentials()
            {
                email = email,
                password = _context.computeHash(password),
                lastLogin = "Never",
                sysadmin = sysadmin
            };

            _context.addEntry(newcredential);

            return PartialView("_PartialAccount");
        }



        /* ========================================= */
        /*     DATA MANIPULATION / LOGIC HANDLERS    */
        /* ========================================= */

        /* Show graph */
        public IActionResult showGraph(modelDataResult result)
        {
            return View(generateGraph(result));
        }

        /* Generate graph */ 
        public modelGraph generateGraph(modelDataResult result)
        {
            modelGraph graph = new modelGraph();

            int itx = 0;
            string path = _context.returnResultFromID(result.ID).rawAddress;
            int fileLength = System.IO.File.ReadLines(path).ToArray().Length;

            foreach (string line in System.IO.File.ReadLines(path))
            {

                if ((itx > 4 && itx < fileLength - 3) && (!line.Equals("")))
                {
                    var splitLine = line.Split(",");

                    for (int i = 0; i <= splitLine.Length - 1; i++)
                    {
                        if (splitLine[i] == null || splitLine[i].Equals(" "))
                        {
                            splitLine[i] = "0";
                        }
                    }

                    graph.axisX += String.Format(splitLine[0] + ",");
                    graph.plate += String.Format(splitLine[1] + ",");
                    graph.tube += String.Format(splitLine[2] + ",");
                    graph.diskTop += String.Format(splitLine[3] + ",");
                    graph.diskBottom += String.Format(splitLine[4] + ",");
                    graph.fluidTemp += String.Format(splitLine[5] + ",");
                    graph.piezoCurrent += String.Format(splitLine[6] + ",");
                    //graph.ledCurrent += String.Format(splitLine[7] + ",");

                }

                else if (itx == fileLength - 3)
                {
                    break;
                }

                itx++;
            }

            return graph;
        }

        /* Convert naming */
        public string convertFileName(string file)
        {
            String[] splitted = file.Split("_");
            List<string> datetime = splitted[2].Split("-").ToList();

            datetime.Add(splitted[3]);

            if (datetime[4].Contains("AM"))
            {
                datetime[4] = datetime[4].Replace("AM", "").Replace(".txt", "");
            }

            else if (datetime[4].Contains("PM"))
            {
                datetime[4] = datetime[4].Replace("PM", "").Replace(".txt", "");

                if (!datetime[3].Equals("12"))
                {
                    datetime[3] = (int.Parse(datetime[3]) + 12).ToString();
                }

            }

            DateTime time = new DateTime(int.Parse("20" + datetime[2]), int.Parse(datetime[0]), int.Parse(datetime[1]), int.Parse(datetime[3]), int.Parse(datetime[4]), 0);

            string TIME = time.ToString();

            string filename = time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + "_" + time.Hour + time.Minute + "_" + splitted[1];

            return filename;
        }

        /* Migrate */
        public void batchMerge(string baseDirectory)
        {
            //These SIGNALR warnings are okay

            HttpContext.Session.SetInt32("progress", 1);

            sendLog("...");
            sendLog("Starting batch merge...");

            double total = 0;
            double idx = 0;
            Array.ForEach(Directory.GetDirectories(baseDirectory), x => total += Directory.GetFiles(x).Where(file => file.Split(@"\").Last().Split("_")[0].Equals("LOG")).ToArray().Length);


            foreach (String dir in Directory.GetDirectories(baseDirectory))
            {
                string dateString = dir.Split(@"\").Last();
                DateTime date = DateTime.ParseExact(dir.Split("\\").Last(), "MMddyy", CultureInfo.InvariantCulture);
                string path = (@"C:\Users\griff\Documents\TangenDataStore\" + dateString);


                //Create date directory (ex: 021118)
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    sendLog("New directory '" + dir.Split("\\").Last() + "' created");
                }

                foreach (String file in Directory.GetFiles(dir))
                {
                    string fileName = file.Split(@"\").Last();
                    //Check if its a log file
                    if (fileName.Contains("LOG"))
                    {
                        foreach (String subfile in Directory.GetFiles(dir))
                        {
                            //For every log file check for a corresponding run file
                            HttpContext.Session.SetInt32("progress", (HttpContext.Session.GetInt32("progress") ?? 1) + 1);

                            if (subfile.Contains("RUN"))
                            {
                                string x = subfile.Split(@"\").Last().Replace("RUN", "LOG");
                                if (x.Equals(fileName))
                                {
                                    //Set new paths
                                    string newName = convertFileName(file.Split(@"\").Last());
                                    string newPath = path + @"\LOG_" + newName + ".txt";

                                    string newNameRUN = convertFileName(subfile.Split(@"\").Last());
                                    string newPathRUN = path + @"\RUN_" + newName + ".txt";

                                    //If the run file is found then copy the log file to serverside storage
                                    try
                                    {
                                        System.IO.File.Copy(file, newPath);
                                        System.IO.File.Copy(subfile, newPathRUN);
                                    }
                                    catch (Exception ex)
                                    {
                                        sendLog("cant write file");
                                    }

                                    //Adding data to database for runs and tracker tables
                                    modelDataResult data = new modelDataResult()
                                    {
                                        uniqueID = newName,
                                        rawAddress = newPath,
                                        downloadDateTime = date.ToString()
                                    };

                                    modelTracker tracker = new modelTracker()
                                    {
                                        dateTime = date.ToString(),
                                        uniqueID = newName
                                    };

                                    _context.addEntry(tracker);
                                    _context.addEntry(data);

                                    //sendLog("Merged file '" + subfile + "' \u001b[32msuccessfully\u001b[0m");
                                    idx++;
                                    updateProgressBar((idx / total) * 100);

                                }
                            }

                        }
                    }


                }
                
            }

            sendLog("\u001b[32mMerge completed successfully!\u001b[0m");

        }

        /* Generate report */
        public IActionResult Report(modelDataResult result)
        {

            modelTarget[] targets = _context.returnTargets(result.ID);
            modelWell[] wells = _context.returnWells(result.ID);
            List<modelStats> statsList = new List<modelStats>();
            string cq = "";
            string wellno = "";

            foreach (modelTarget target in targets)
            {
                modelStats model = new modelStats()
                {
                    species = target.Name,
                    result = Convert.ToInt32(target.Outcome)
                };

                statsList.Add(model);

            }

            int idx = 1;
            foreach (modelWell well in wells)
            {
                cq += (well.Cq + ",");
                wellno += (idx + ",");

                idx++;
            }

            modelPackage pckg = new modelPackage()
            {
                singularResult = _context.returnResultFromID(result.ID),
                graph = generateGraph(result),
                cqList = cq,
                wellnoList = wellno,
                stats = statsList.ToArray()
            };

            return View(pckg);
        }



        /* ========================================= */
        /*             DOWNLOAD HANDLERS             */
        /* ========================================= */

        /* Results JSON download handler */
        public IActionResult downloadHandlerResult(modelDataResult data)
        {

            data.targets = _context.returnTargets(data.ID);
            data.wells = _context.returnWells(data.ID);

            string resultsJSON = JsonConvert.SerializeObject(data, Formatting.Indented);
            Stream memstream = new MemoryStream(Encoding.ASCII.GetBytes(resultsJSON));
            return File(memstream, "application/json", data.instrumentName + "-" + data.sampleID + "-" + System.DateTime.Now.ToString() + ".json");
        }

        /* Raw data download handler */
        public FileResult downloadHandlerRaw(modelDataResult data)
        {
            string path = (_context.getRaw(data.uniqueID).rawAddress).Replace("LOG", "RUN");
            string filename = path.Split(@"\").Last();

            if (System.IO.File.Exists(path))
            {
                try
                {
                    FileStream fs = System.IO.File.OpenRead(path);
                    return File(fs, "text/plain", filename);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                
            }

            return null;
        }

        public FileResult downloadHandlerCSV(modelDataResult data)
        {

            string path = (_context.getRaw(data.uniqueID).rawAddress).Replace("LOG", "RUN");
            string filename = path.Split(@"\").Last().Replace("txt", "csv");

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.FileName = @"C:\Users\griff\Workspace\TangenBiosciences\Tangen\TangenDataPortal\Portal\Portal\scripts\JSONrawdataconvert.exe";
            startInfo.Arguments = "-p " + path;

            if (System.IO.File.Exists(path))
            {
                try
                {

                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                        FileStream fs = System.IO.File.OpenRead(path);
                        return File(fs, "text/plain", filename);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            return null;

        }

            
        /* Batch download handler */
        public FileResult batchDownloadHandler(string input)
        {
            byte[] fileBytes = null;

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (string idStr in input.Split(","))
                    {
                        int id = Convert.ToInt32(idStr);
                        modelDataResult result = _context.returnResultFromID(id);

                        result.targets = _context.returnTargets(id);
                        result.wells = _context.returnWells(id);

                        string resultsJSON = JsonConvert.SerializeObject(result, Formatting.Indented);
                        var demoFile = archive.CreateEntry(result.uniqueID + ".json");

                        using (var entryStream = demoFile.Open())
                        using (var streamWriter = new StreamWriter(entryStream))
                        {
                            streamWriter.Write(resultsJSON);
                        }
                    }
                }

                fileBytes = memoryStream.ToArray();

                Stream memstream = new MemoryStream(fileBytes);
                return File(memstream, "application/zip", System.DateTime.Now + ".zip");
            }



        }


        /* ========================================= */
        /*                   OTHER                   */
        /* ========================================= */

        /* View database */
        public IActionResult viewDatabase()
        {
            return View("DatabaseView", _context.allResults());
        }

        /* View trackers */
        public IActionResult viewDatabaseTrackers()
        {
            return View("DatabaseView", _context.allTrackers());
        }

        /* View instruments */
        public IActionResult viewDatabaseInstruments()
        {
            return View("DatabaseView", _context.returnAllInstruments());
        }

        /* View users */
        public IActionResult viewDatabaseUsers()
        {
            return View("DatabaseView", _context.returnAllAccounts());
        }

        /* View results JSON handler */
        public JsonResult viewResults(modelDataResult data)
        {

            data.targets = _context.returnTargets(data.ID);
            data.wells = _context.returnWells(data.ID);

            string resultsJSON = JsonConvert.SerializeObject(data, Formatting.Indented);

            return Json(JObject.Parse(resultsJSON));
        }




    }
}
