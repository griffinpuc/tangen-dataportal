using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class modelTag
    {

        public int ID { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        [JsonIgnore]
        public int? DataID { get; set; }
        [JsonIgnore]
        public virtual modelDataResult Data { get; set; }

    }
}
