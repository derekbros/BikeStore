using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

#nullable disable

namespace BikeAgencyLibrary
{
    public partial class Rental
    {
        [BindNever]
        public int RentalId { get; set; }        
                [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public int BikeId { get; set; }
        public int CustId { get; set; }
        public int RateId { get; set; }
        public bool PaymentStatusCode { get; set; }
        public DateTime BookedStartDateTime { get; set; }
        public DateTime BookedEndDateTime { get; set; }
        public DateTime? ActualStartDateTime { get; set; }
        public DateTime? ActualEndDateTime { get; set; }
        public string RentalPaymentDue { get; set; }
        public string RentalPaymentMade { get; set; }
        public string OtherDetails { get; set; }

        public virtual Bike Bike { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual PaymentStatus PaymentStatusCodeNavigation { get; set; }
        [BindNever]
        public bool Rented { get; set; }


    }
}
