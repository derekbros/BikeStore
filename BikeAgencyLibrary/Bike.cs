﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BikeAgencyLibrary
{
    public partial class Bike
    {
        public Bike()
        {
            BikesInShops = new HashSet<BikesInShop>();
            Rentals = new HashSet<Rental>();
        }

        public int BikeId { get; set; }
        public int TypeId { get; set; }
        public string Size { get; set; }
        public string Location { get; set; }
        public int RateId { get; set; }
        public int FeatureId { get; set; }

        public virtual SpecialFeature Feature { get; set; }
        public virtual RentalRate Rate { get; set; }
        public virtual ICollection<BikesInShop> BikesInShops { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }

        [NotMapped]
        public virtual BikeType Type { get; set; }
    }
}
