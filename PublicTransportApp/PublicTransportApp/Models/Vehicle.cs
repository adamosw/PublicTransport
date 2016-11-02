using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportApp.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool isLowerDeck { get; set; }
        public bool isAirConditioned { get; set; }
        public virtual ICollection<Stop> Stops { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}