using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BikeAgencyLibrary
{
    public partial class RentalDetail
    {
        public int RentalDetailId { get; set; }
        public int Qty { get; set; }
        public int BikeId { get; set; }
        public int RateId { get; set; }
        [ForeignKey(nameof(BikeId))]
        public virtual Bike Bike { get; set; }
        [ForeignKey(nameof(RateId))]
        public virtual RentalRate Rate { get; set; }
        public virtual Rental Rental { get; set; }
    }
}
