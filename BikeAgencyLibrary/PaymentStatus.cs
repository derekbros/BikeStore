using System;
using System.Collections.Generic;

#nullable disable

namespace BikeAgencyLibrary
{
    public partial class PaymentStatus
    {
        public PaymentStatus()
        {
            Rentals = new HashSet<Rental>();
        }

        public int PaymentStatusId { get; set; }
        public bool PaymentStatusCode { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatusDescription { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
