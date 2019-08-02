using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public partial class modelWell
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string wId { get; set; }
        public string Species { get; set; }
        public string Cq { get; set; }
        [JsonIgnore]
        public int? DataID { get; set; }
        [JsonIgnore]
        public virtual modelDataResult Data { get; set; }
    }
}
