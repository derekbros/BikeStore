using System;
using System.Collections.Generic;

#nullable disable

namespace BikeAgencyLibrary
{
    public partial class Shop
    {
        public Shop()
        {
            Employees = new HashSet<Employee>();
        }

        public int ShopId { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string State { get; set; }
        public string AddressLine2 { get; set; }

        public virtual BikesInShop BikesInShop { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }.
        
          public IEnumerable<Bike> Bikes { get; set; }
    }
}
