using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportApp.Models
{
    public class Section
    {
        public int SectionID { get; set; }
        public double Start_Longitude { get; set; }
        public double Start_Latitude { get; set; }
        public double End_Longitude { get; set; }
        public double End_Latitude { get; set; }
        public int Order { get; set; }
        public virtual Route Route { get; set; }
    }
}