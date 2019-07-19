using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public partial class modelTarget
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string targetId { get; set; }
        public string Name { get; set; }
        public string Outcome { get; set; }
        [JsonIgnore]
        public int? DataID { get; set; }
        [JsonIgnore]
        public virtual modelDataResult Data { get; set; }
    }
}
