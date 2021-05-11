using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeAgencyLibrary;

namespace BikeRentalAgency.Models.ViewModels
{
    public class RentalsListViewModel
    {
        public IList<Bike> Bikes { get; set; } = new List<Bike>();
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}