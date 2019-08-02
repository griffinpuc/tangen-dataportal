using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Models
{
    public class modelDataResult
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)][JsonIgnore]
        public int ID { get; set; }
        public string sampleID { get; set; }
        public string uniqueID { get; set; }
        public string downloadDateTime { get; set; }
        public string assayID { get; set; }
        public string kitLotID { get; set; }
        public string instrumentUUID { get; set; }
        public string instrumentName { get; set; }

        [JsonIgnore]
        public string rawAddress { get; set; }

        [JsonIgnore]
        public ICollection<modelTag> tags { get; set; }

        public ICollection<modelTarget> targets { get; set; }
        public ICollection<modelWell> wells { get; set; }
    }
}
