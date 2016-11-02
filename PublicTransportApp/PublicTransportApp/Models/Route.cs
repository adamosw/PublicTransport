using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportApp.Models
{
    public class Route
    {
        public int RouteID { get; set; }
        public double Start_Longitude { get; set; }
        public double Start_Latitude { get; set; }
        public double End_Longitude { get; set; }
        public double End_Latitude { get; set; }
        public bool isStartingRoute { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}