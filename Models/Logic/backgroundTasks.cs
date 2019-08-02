using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Portal.Controllers;

namespace Portal.Models.Logic
{
    public class backgroundTasks
    {
        private contextDatabase _context;
        public backgroundTasks(contextDatabase context)
        {
            _context = context;
        }

        public modelPackage updatePage(int num)
        {
            modelPackage retPckg = new modelPackage() { dataresults = _context.allResultsNewSort(num) };

            return retPckg;
        }

        public void updateConnections()
        {
            modelInstruments[] instrumentsArray = _context.returnAllInstruments().Where(x => x.status.Equals("IDLE")).ToArray();
            globalData.connectedInstruments = instrumentsArray.Length;
        }

    }
}
