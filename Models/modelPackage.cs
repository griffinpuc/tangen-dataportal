using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models 
{
    public class modelPackage
    {

        //ANYTHING YOU MAY NEED TO PACKAGE FOR VIEW MODEL
        public modelCredentials[] credentials { get; set; }
        public modelDataResult[] dataresults { get; set; }
        public modelInstruments[] instruments { get; set; }
        public modelTag[] tags { get; set; }
        public modelDataResult singularResult { get; set; }
        public modelTag singularTag { get; set; }
        public modelGraph graph { get; set; }
        public modelStats[] stats { get; set; }


        public string cqList { get; set; }
        public string wellnoList { get; set; }


        public int connectedInstruments { get; set; }
        public int totalInstruments { get; set; }
        public int count { get; set; }
        public int counttrack { get; set; }
        public bool issys { get; set; }
        public int loadedcount { get; set; }
        public int countresults { get; set; }
        public int countusers { get; set; }
        public string progress { get; set; }
        public string elapsed { get; set; }
        public string endtime { get; set; }
        public int progress2 { get; set; }
        public int total { get; set; }
    }

    public class modelStats
    {
        public string species { get; set; }
        public int result { get; set; }
    }
}
