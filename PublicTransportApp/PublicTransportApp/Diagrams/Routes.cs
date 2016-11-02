//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PublicTransportApp.Diagrams
{
    using System;
    using System.Collections.Generic;
    
    public partial class Routes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Routes()
        {
            this.Sections = new HashSet<Sections>();
        }
    
        public int RouteID { get; set; }
        public double Start_Longitude { get; set; }
        public double Start_Latitude { get; set; }
        public double End_Longitude { get; set; }
        public double End_Latitude { get; set; }
        public bool isStartingRoute { get; set; }
        public Nullable<int> Vehicle_VehicleID { get; set; }
    
        public virtual Vehicles Vehicles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sections> Sections { get; set; }
    }
}