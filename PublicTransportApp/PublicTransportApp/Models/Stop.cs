using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportApp.Models
{
    public class Stop
    {
        public int StopID { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}