using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeAgencyLibrary;

namespace BikeRentalAgency.Models.ViewModels
{
    public class BikeViewModel
    {

        public Bike Bike { get; set; }
        public string Action { get; set; } = "Create";
        public bool ReadOnly { get; set; } = false;
        public string Theme { get; set; } = "primary";
        public bool ShowAction { get; set; } = true;
        public IEnumerable<BikeType> BikeType { get; set; }
        = Enumerable.Empty<BikeType>();
        public IEnumerable<Shop> Shop { get; set; }
        = Enumerable.Empty<Shop>();
    }
}
