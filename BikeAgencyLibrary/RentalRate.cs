using System;
using System.Collections.Generic;

#nullable disable

namespace BikeAgencyLibrary
{
    public partial class RentalRate
    {
        public RentalRate()
        {
            Bikes = new HashSet<Bike>();
        }

        public int RentalRateId { get; set; }
        public double? DailyRate { get; set; }
        public decimal? HourlyRate { get; set; }

        public virtual ICollection<Bike> Bikes { get; set; }
    }
}
