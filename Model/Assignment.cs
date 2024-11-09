using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AssetManagement.Model
{
    public class Assignment
    {
        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("asset")]
        public string Asset { get; set; }

        [JsonProperty("assignedDate")]
        public string AssignedDate { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
    }
}
