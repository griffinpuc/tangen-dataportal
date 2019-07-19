using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Portal.Models;
using Portal.Models.Logic;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {

        private contextDatabase _context;
        private backgroundTasks _task;
        public HomeController(contextDatabase context)
        {
            _context = context;
            _task = new backgroundTasks(context);
        }

        /* Main index view*/
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("load_no", 1);

            modelPackage pckg = new modelPackage();
            pckg.instruments = _context.returnAllInstruments();
            pckg.tags = _context.returnAllTags();

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
            modelPackage pckg = new modelPackage();
            pckg.dataresults = _context.returnAllResultsNew(HttpContext.Session.GetInt32("load_no") ?? 1);
            pckg.tags = _context.returnAllTags();

            HttpContext.Session.SetInt32("load_no", pckg.dataresults.Count());

            return PartialView("_PartialData", pckg);
        }

        /* Add new tag */
        public void addTag(int tagID, int dataresultID)
        {
            modelDataResult dataresult = _context.dataresultTable.Single(a => a.ID == dataresultID);
            modelTag tag = _context.tagsTable.Single(a => a.ID == tagID);

            modelTag new_tag = new modelTag() { name = tag.name, color = tag.color };

            List<modelTag> taglist;

            if(dataresult.tags == null)
            {
                taglist = new List<modelTag>();
            }
            else
            {
                taglist = dataresult.tags.ToList();
            }

            if (taglist.Contains(tag))
            {
                taglist.Remove(tag);
            }
            else
            {
                taglist.Add(new_tag);
            }

            dataresult.tags = taglist.ToArray();
            _context.updateEntry(dataresult);


        }

        /* Load more results */
        public IActionResult loadMore()
        {
            HttpContext.Session.SetInt32("load_no", (HttpContext.Session.GetInt32("load_no")??1) + 1);

            modelPackage pckg = new modelPackage();
            pckg.dataresults = _context.returnAllResultsNew(HttpContext.Session.GetInt32("load_no") ?? 1);
            pckg.tags = _context.returnAllTags();

            return PartialView("_PartialData", pckg);
        }

        /* Update data model */
        public IActionResult updateButton()
        {
            int i = _context.returnAllResultsNew(HttpContext.Session.GetInt32("load_no") ?? 1).Length;
            int x = HttpContext.Session.GetInt32("lastAmount") ?? 1;

            return PartialView("_PartialButton", (_context.returnAllResultsNew(HttpContext.Session.GetInt32("load_no") ?? 1).Length - HttpContext.Session.GetInt32("lastAmount")));
        }

        /* Update connections model */
        public IActionResult updateConnections()
        {
            _task.updateConnections();
            return PartialView("_PartialIndexInstruments", new modelPackage()
            {
                 connectedInstruments = globalData.connectedInstruments,
                 totalInstruments = _context.returnAllInstruments().Length,
                 instruments = _context.returnAllInstruments(),
                 count = _context.returnTableCount()
            });
        }

        /* Update database management */
        public IActionResult updateDatabasePanel()
        {
            modelPackage pckg = new modelPackage()
            {
                count = _context.returnTableCount(),
                counttrack = _context.returnTableCountTrack()
            };

            return PartialView("_PartialDBManage", pckg);
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

        /* Add new tag to database */
        public IActionResult addNewTag(string name)
        {
            var random = new Random();
            modelTag newtag = new modelTag();
            newtag.name = name;
            newtag.color = String.Format("#{0:X6}", random.Next(0x1000000));

            _context.addEntry(newtag);

            modelPackage pckg = new modelPackage();
            pckg.tags = _context.returnAllTags();

            return PartialView("_PartialTagDrop", pckg);
        }

        /* Update tags partial view */
        public IActionResult updateDataTags()
        {
            modelPackage pckg = new modelPackage();
            pckg.tags = _context.returnAllTags();

            return PartialView("_PartialTags", pckg);
        }

        /* Update data model on search term enter */
        public IActionResult updateFromSearch(string term)
        {
            modelDataResult[] retval;
            int num = HttpContext.Session.GetInt32("load_no") ?? 1;

            if (term == null)
            {
                retval = _context.returnAllResultsNew(HttpContext.Session.GetInt32("load_no") ?? 1);
            }

            else
            {
                retval = _context.getFromSearch(term, num);
            }

            modelPackage pckg = new modelPackage();
            pckg.dataresults = retval;
            pckg.tags = _context.returnAllTags();


            return PartialView("_PartialData", pckg);
        }

        /* Sort results ny new */
        public IActionResult sortNew()
        {
            return PartialView("_PartialData", _context.returnAllResultsNew(HttpContext.Session.GetInt32("load_no") ?? 1));
        }

        /* Sort results by old */
        public IActionResult sortOld()
        {
            return PartialView("_PartialData", _context.returnAllResultsOld(HttpContext.Session.GetInt32("load_no") ?? 1));
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
            else if(returned == 2)
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
        public IActionResult downloadHandlerRaw(modelDataResult data)
        {
            Stream memstream = new MemoryStream(Encoding.ASCII.GetBytes(_context.getRaw(data.uniqueID).path));
            return File(memstream, "application/octet-stream", data.instrumentName + "-" + data.sampleID + "-" + System.DateTime.Now.ToString() + ".brd");
        }

        /* View results JSON handler */
        public JsonResult viewResults(modelDataResult data)
        {

            data.targets = _context.returnTargets(data.ID);
            data.wells = _context.returnWells(data.ID);

            string resultsJSON = JsonConvert.SerializeObject(data, Formatting.Indented);
            return Json(JObject.Parse(resultsJSON));
        }

        /* Add new instrument */
        public IActionResult addInstrument(string instrumentname, string instrumentaddress)
        {
            if(!(instrumentaddress == null || instrumentname == null))
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
    }
}
