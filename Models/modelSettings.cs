using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class modelSettings
    {
        public string version { get; set; }
        public tdpSettings tdpSettings { get; set; }
    }

    public class tdpSettings
    {
        public string datastorePath { get; set; }
        public bool logging { get; set; }
    }
}
