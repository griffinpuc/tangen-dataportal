using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class modelCredentials
    {
        public int ID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string lastLogin { get; set; }
        public bool sysadmin { get; set; }
    }
}
