using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ResourceManager.WebAPI.Models
{
    public class Resource
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("blood_group")]
        public string BloodGroup { get; set; }

        [JsonProperty("hierarchy")]
        public string Hierarchy { get; set; }

        [JsonProperty("reserve1")]
        public string Reserve1 { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }
    }
}