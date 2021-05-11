using System;
using System.Collections.Generic;

namespace BikeAgencyLibrary
{
    public partial class SpecialFeature
    {
        public SpecialFeature()
        {
            Bikes = new HashSet<Bike>();
        }

        public int SpecialFeatureId { get; set; }
        public bool ElectricMotor { get; set; }
        public bool Basket { get; set; }
        public string Color { get; set; }
        public bool AllTerrain { get; set; }
        public bool ChildSeat { get; set; }

        public virtual ICollection<Bike> Bikes { get; set; }
    }
}
