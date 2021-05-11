using System;
using System.Collections.Generic;

#nullable disable

namespace BikeAgencyLibrary
{
    public partial class Customer
    {
        public Customer()
        {
            Rentals = new HashSet<Rental>();
        }

        public int CustomerId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
