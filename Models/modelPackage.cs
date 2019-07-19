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
        public int connectedInstruments { get; set; }
        public int totalInstruments { get; set; }
        public int count { get; set; }
        public int counttrack { get; set; }
        public bool issys { get; set; }
        public int loadedcount { get; set; }
    }
}
