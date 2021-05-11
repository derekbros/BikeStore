using System;
using System.Collections.Generic;

#nullable disable

namespace BikeAgencyLibrary
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public int ShopId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Password { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
