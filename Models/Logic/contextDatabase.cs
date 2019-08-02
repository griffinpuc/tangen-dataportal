using Hangfire;
using Microsoft.EntityFrameworkCore;
using Portal.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class contextDatabase : DbContext
    {

        /* =========================================
           =        TDP: DATABASE CONTEXT          =
           =                                       =
           =========================================

            [] DB TABLES
            [] DATABASE HANDLERS
            [] QUERIES
            [] LOGICAL FUNCTIONS

        */



        /* Database connection context */
        public contextDatabase(DbContextOptions<contextDatabase> options)
            : base(options)
        {
        }



        /* ========================================= */
        /*            INITIALIZE DB TABLES           */
        /* ========================================= */

        public DbSet<modelTracker> trackersTable { get; set; }
        public DbSet<modelDataResult> dataresultTable { get; set; }
        public DbSet<modelCredentials> credentialsTable { get; set; }
        public DbSet<modelInstruments> instrumentsTable { get; set; }
        public DbSet<modelTarget> modelTarget { get; set; }
        public DbSet<modelWell> modelWell { get; set; }
        public DbSet<modelRawResult> rawindexTable { get; set; }
        public DbSet<modelTag> tagsTable { get; set; }



        /* ========================================= */
        /*             DATABASE HANDLERS             */
        /* ========================================= */

        /* Add entry */
        public void addEntry(object obj)
        {
            Add(obj);
            SaveChanges();
        }

        /* Remove entry */
        public void removeEntry(object obj)
        {
            Remove(obj);
            SaveChanges();
        }

        /* Modify entry */
        public void updateEntry(object obj)
        {
            Update(obj);
            SaveChanges();
        }

        public void vanquish()
        {
            Database.ExecuteSqlCommand("Delete from trackersTable");
            Database.ExecuteSqlCommand("Delete from modelTarget");
            Database.ExecuteSqlCommand("Delete from modelWell");
            SaveChanges();
            Database.ExecuteSqlCommand("Delete from dataresultTable");
            SaveChanges();
        }



        /* ========================================= */
        /*                  QUERIES                  */
        /* ========================================= */


        public int resultsCount()
        {
            return (from modelDataResult in dataresultTable select modelDataResult).ToList().ToArray().Length;
        }

        public modelDataResult[] allResults()
        {
            return (from modelDataResult in dataresultTable select modelDataResult).ToList().ToArray();
        }

        public modelDataResult[] allResultsNewSort(int num)
        {
            return (from modelDataResult in dataresultTable select modelDataResult).ToList().OrderByDescending(d => Convert.ToDateTime(d.downloadDateTime)).Take(15 * num).ToArray();
        }

        public modelDataResult[] limResults(int num)
        {
            return (from modelDataResult in dataresultTable select modelDataResult).Take(15 * num).ToList().ToArray();
        }

        public modelTracker[] allTrackers()
        {
            return (from modelTracker in trackersTable select modelTracker).ToList().ToArray();
        }






        ///* Return ALL-LIMITED results (query limited) */
        //public modelDataResult[] returnAllResults(int num)
        //{
        //    return (from modelDataResult in dataresultTable select modelDataResult).Take(15*num).ToList().ToArray();
        //}

        ///* Return ALL results (query not limited) */
        //public modelDataResult[] returnAllAbsolute()
        //{
        //    return (from modelDataResult in dataresultTable select modelDataResult).ToList().ToArray();
        //}

        /* Return ALL instruments */
        public modelInstruments[] returnAllInstruments()
        {
            return (from modelInstruments in instrumentsTable select modelInstruments).ToList().ToArray();
        }

        /* Return ALL ACTIVE instruments */
        public modelInstruments[] returnAllActiveInstruments()
        {
            return (from modelInstruments in instrumentsTable where modelInstruments.status.Equals("IDLE") select modelInstruments).ToList().ToArray();
        }

        /* Return ALL accounts */
        public modelCredentials[] returnAllAccounts()
        {
            return (from modelCredentials in credentialsTable select modelCredentials).ToList().ToArray();
        }

        /* Return ALL targets */
        public modelTarget[] returnTargets(int dataTableID)
        {
            return (from modelTarget in modelTarget where modelTarget.DataID == dataTableID select modelTarget).ToList().ToArray();
        }

        /* Return ALL wells */
        public modelWell[] returnWells(int dataTableID)
        {
            return (from modelWell in modelWell where modelWell.DataID == dataTableID select modelWell).ToList().ToArray();
        }

        ///* Return ALL tags */
        //public modelTag[] returnAllTags()
        //{
        //    //return (from modelTag in tagsTable select modelTag).ToList().ToArray();
        //    return null;
        //}

        /* Return SOME-LIMITED results WITHIN timeframe */
        public modelDataResult[] returnallResultsTimeframe(DateTime startTime, DateTime endTime, int num)
        {
            var endTimeExclusive = endTime.AddDays(1);
            return (from modelDataResult in dataresultTable select modelDataResult).ToList().Where(obj => Convert.ToDateTime(obj.downloadDateTime.Split(" ")[0]) >= startTime && Convert.ToDateTime(obj.downloadDateTime.Split(" ")[0]) < endTimeExclusive).OrderByDescending(d => Convert.ToDateTime(d.downloadDateTime)).Take(15 * num).ToArray();
        }

        /* Return ALL-LIMITED results WITHIN timeframe */
        public modelDataResult[] returnallResultsTimeframeAll(DateTime startTime, DateTime endTime)
        {
            var endTimeExclusive = endTime.AddDays(1);
            return (from modelDataResult in dataresultTable select modelDataResult).ToList().Where(obj => Convert.ToDateTime(obj.downloadDateTime.Split(" ")[0]) >= startTime && Convert.ToDateTime(obj.downloadDateTime.Split(" ")[0]) < endTimeExclusive).OrderByDescending(d => Convert.ToDateTime(d.downloadDateTime)).ToArray();
        }

        /* Return SOME results WITHIN timeframe (query not limited) */
        public modelDataResult[] returnallabsoluteResultsTimeframe(DateTime startTime, DateTime endTime, int num)
        {
            var endTimeExclusive = endTime.AddDays(1);
            return (from modelDataResult in dataresultTable select modelDataResult).ToList().Where(obj => Convert.ToDateTime(obj.downloadDateTime.Split(" ")[0]) >= startTime && Convert.ToDateTime(obj.downloadDateTime.Split(" ")[0]) < endTimeExclusive).OrderByDescending(d => Convert.ToDateTime(d.downloadDateTime)).ToArray();
        }

        ///* Return ALL-LIMITED results OLD-FIRST */
        //public modelDataResult[] returnAllResultsOld(int num)
        //{
        //    return (from modelDataResult in dataresultTable select modelDataResult).ToList().OrderBy(d => Convert.ToDateTime(d.downloadDateTime)).Take(15 * num).ToArray();
        //}

        ///* Return ALL-LIMITED results NEW-FIRST */
        //public modelDataResult[] returnAllResultsNew(int num)
        //{
        //    return (from modelDataResult in dataresultTable select modelDataResult).ToList().OrderByDescending(d => Convert.ToDateTime(d.downloadDateTime)).Take(15 * num).ToArray();
        //}

        ///* Return COUNT of ALL dataresults */
        //public int returnTableCount()
        //{
        //    return (returnAllAbsolute().Count());
        //}

        /* Return COUNT of ALL trackers */
        public int returnTableCountTrack()
        {
            return (allTrackers().Count());
        }

        /* Return instrument object from ID */
        public modelInstruments returnInstrumentFromID(int instrumentID)
        {
            return (from modelInstruments in instrumentsTable where modelInstruments.ID == instrumentID select modelInstruments).FirstOrDefault();
        }

        /* Return dataresult object from ID */
        public modelDataResult returnResultFromID(int resultID)
        {
            return (from modelDataResult in dataresultTable where modelDataResult.ID == resultID select modelDataResult).FirstOrDefault();
        }

        /* Return account object from ID */
        public modelCredentials returnUserFromID(int userID)
        {
            return (from modelCredentials in credentialsTable where modelCredentials.ID == userID select modelCredentials).FirstOrDefault();
        }

        /* Get raw address from ID */
        public modelDataResult getRaw(string uniqueID)
        {
            return (from modelDataResult in dataresultTable where modelDataResult.uniqueID == uniqueID select modelDataResult).FirstOrDefault();
        }

        public modelDataResult[] getFromSearchAll(string term, modelDataResult[] results)
        {
            return getFromSearch(term, 50000, results);
        }

        /* Get SOME-LIMITED dataresults from search */
        public modelDataResult[] getFromSearch(string term, int num, modelDataResult[] results)
        {
            if (results == null)
            {
                results = allResults();
            }

            PropertyInfo[] properties = typeof(modelDataResult).GetProperties();
            List<modelDataResult> retval = new List<modelDataResult>();

            foreach (modelDataResult data in results)
            {
                foreach (PropertyInfo property in properties)
                {
                    if (property.GetValue(data, null) != null)
                    {
                        if (property.GetValue(data, null).ToString().Contains(term))
                        {
                            retval.Add(data);
                            break;
                        }
                    }
                }
            }


            return retval.ToArray();

        }

        ///* Remove ALL FROM ALL */
        //public void removeAllResults()
        //{
        //    Database.ExecuteSqlCommand("TRUNCATE TABLE trackersTable");
        //    //Database.ExecuteSqlCommand("TRUNCATE TABLE modelTarget");
        //    //Database.ExecuteSqlCommand("TRUNCATE TABLE modelWell");
        //    Database.ExecuteSqlCommand("TRUNCATE TABLE dataresultTable");
        //}



        /* ========================================= */
        /*             LOGICAL FUNCTIONS             */
        /* ========================================= */

        /* Compute hash from string */
        public string computeHash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        /* Use computeHash to verify credentials */
        public int secureLogin(string email, string password)
        {
            //Add(new modelCredentials() { email = "admin@admin", password = ComputeHash("alpine") });
            //SaveChanges();
            modelCredentials dbEmail;
            dbEmail = credentialsTable.FirstOrDefault(t => t.email == email);

            int retval = 0;

            if(dbEmail != null)
            {
                if ((computeHash(password).Equals(dbEmail.password)))
                {
                    retval = 1;

                    if (dbEmail.sysadmin)
                    {
                        retval = 2;
                    }
                }

                dbEmail.lastLogin = System.DateTime.Now.ToString();
                Update(dbEmail);
                SaveChanges();
            }

            return retval;
        }
    }
}
