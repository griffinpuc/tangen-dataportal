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

        public contextDatabase(DbContextOptions<contextDatabase> options)
            : base(options)
        {
        }

        public DbSet<modelTracker> trackersTable { get; set; }
        public DbSet<modelDataResult> dataresultTable { get; set; }
        public DbSet<modelCredentials> credentialsTable { get; set; }
        public DbSet<modelInstruments> instrumentsTable { get; set; }
        public DbSet<modelTarget> modelTarget { get; set; }
        public DbSet<modelWell> modelWell { get; set; }
        public DbSet<modelRawResult> rawindexTable { get; set; }
        public DbSet<modelTag> tagsTable { get; set; }

        /* Database handlers */
        public void addEntry(object obj)
        {
            Add(obj);
            SaveChanges();
        }

        public void removeEntry(object obj)
        {
            Remove(obj);
            SaveChanges();
        }

        public void updateEntry(object obj)
        {
            Update(obj);
            SaveChanges();
        }

        /* Database queries */
        public modelDataResult[] returnAllResults(int num)
        {
            return (from modelDataResult in dataresultTable select modelDataResult).Take(15*num).ToList().ToArray();
        }

        public int returnTableCount()
        {
            return(returnAllAbsolute().Count());
        }

        public int returnTableCountTrack()
        {
            return (returnAllAbsoluteTrack().Count());
        }

        public modelDataResult[] returnAllAbsolute()
        {
            return (from modelDataResult in dataresultTable select modelDataResult).ToList().ToArray();
        }


        public modelTracker[] returnAllAbsoluteTrack()
        {
            return (from modelTracker in trackersTable select modelTracker).ToList().ToArray();
        }

        public modelDataResult[] returnAllResultsOld(int num)
        {
            return (from modelDataResult in dataresultTable select modelDataResult).ToList().OrderBy(d => Convert.ToDateTime(d.downloadDateTime)).Take(15 * num).ToArray();
        }

        public modelDataResult[] returnAllResultsNew(int num)
        {
            return (from modelDataResult in dataresultTable select modelDataResult).ToList().OrderByDescending(d => Convert.ToDateTime(d.downloadDateTime)).Take(15 * num).ToArray();
        }

        public modelTracker[] returnAllTrackers()
        {
            return (from modelTracker in trackersTable select modelTracker).ToList().ToArray();
        }

        public modelInstruments[] returnAllInstruments()
        {
            return (from modelInstruments in instrumentsTable select modelInstruments).ToList().ToArray();
        }

        public modelInstruments[] returnAllActiveInstruments()
        {
            return (from modelInstruments in instrumentsTable where modelInstruments.status.Equals("IDLE") select modelInstruments).ToList().ToArray();
        }

        public modelCredentials[] returnAllAccounts()
        {
            return (from modelCredentials in credentialsTable select modelCredentials).ToList().ToArray();
        }

        public modelTarget[] returnTargets(int dataTableID)
        {
            return (from modelTarget in modelTarget where modelTarget.DataID == dataTableID select modelTarget).ToList().ToArray();
        }

        public modelWell[] returnWells(int dataTableID)
        {
            return (from modelWell in modelWell where modelWell.DataID == dataTableID select modelWell).ToList().ToArray();
        }

        public modelInstruments returnInstrumentFromID(int instrumentID)
        {
            return (from modelInstruments in instrumentsTable where modelInstruments.ID == instrumentID select modelInstruments).FirstOrDefault();
        }

        public modelCredentials returnUserFromID(int userID)
        {
            return (from modelCredentials in credentialsTable where modelCredentials.ID == userID select modelCredentials).FirstOrDefault();
        }

        public modelRawResult getRaw(string uniqueID)
        {
            return (from modelRawResult in rawindexTable where modelRawResult.name == uniqueID select modelRawResult).FirstOrDefault();
        }

        public modelTag[] returnAllTags()
        {
            return (from modelTag in tagsTable select modelTag).ToList().ToArray();
        }

        public modelDataResult[] getFromSearch(string term, int num)
        {

            PropertyInfo[] properties = typeof(modelDataResult).GetProperties();
            List<modelDataResult> retval = new List<modelDataResult>();

            if (term.ToCharArray()[0].Equals("#"))
            {
                foreach(modelDataResult result in returnAllAbsolute())
                {
                    foreach(modelTag tag in result.tags)
                    {
                        if (tag.name.Equals(term.Trim('#')))
                        {
                            retval.Add(result);
                        }
                    }
                }
            }

            else
            {
                foreach (modelDataResult data in returnAllAbsolute())
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
            }


            return retval.Take(num*15).ToArray();

        }

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
