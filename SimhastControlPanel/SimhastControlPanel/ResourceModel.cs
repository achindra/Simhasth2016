using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimhastControlPanel
{
    public class ResourceModels
    {
        public List<ResourceModel> JSON;
    }

    /// <summary>
    /// Summary description for ResourceModel
    /// </summary>
    public class ResourceModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string blood_group { get; set; }
        public string hierarchy { get; set; }
        public string reserve1 { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public DateTime last_updated { get; set; }
        public decimal distance { get; set; }

        public ResourceModel()
        {
            //
            // TODO: Add constructor logic here
            //

        }
    }
}
