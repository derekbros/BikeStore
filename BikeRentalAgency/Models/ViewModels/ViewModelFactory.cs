using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using BikeAgencyLibrary;


namespace BikeRentalAgency.Models.ViewModels
{
    public class ViewModelFactory
    {
        public static BikeViewModel Details(Bike b)
        {
            return new BikeViewModel
            {
                Bike = b,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false,
                BikeType = b == null ? Enumerable.Empty<BikeType>()
            : new List<BikeType> { b.BikeType },
                Shop = b == null ? Enumerable.Empty<Shop>()
            : new List<Shop> { b.Shop },
            };
        }

        public static BikeViewModel Create(Bike bike,
            IEnumerable<BikeType> biketype, IEnumerable<Shop> shop)
        {
            return new BikeViewModel
            {
                Bike = bike,
                BikeType = biketype,
                Shop = shop
            };
        }

        public static BikeViewModel Edit(Bike bike,
            IEnumerable<BikeType> biketype, IEnumerable<Shop> shop)
        {
            return new BikeViewModel
            {
                Bike = bike,
                BikeType = biketype,
                Shop = shop,
                Theme = "warning",
                Action = "Edit"
            };
        }

        public static BikeViewModel Delete(Bike b,
            IEnumerable<BikeType> biketype, IEnumerable<Shop> shop)
        {
            return new BikeViewModel
            {
                Bike = b,
                Action = "Delete",
                ReadOnly = true,
                Theme = "danger",
                BikeType = biketype,
                Shop = shop
            };
        }
    }
}

