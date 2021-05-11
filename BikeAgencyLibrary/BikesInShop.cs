using System;
using System.Collections.Generic;

#nullable disable

namespace BikeAgencyLibrary
{
    public partial class BikesInShop
    {
        public int BikesInShopId { get; set; }
        public int? BikeId { get; set; }
        public DateTime DateTimeIn { get; set; }
        public DateTime DateTimeOut { get; set; }
        public string OtherDetails { get; set; }
        public int ShopId { get; set; }

        public virtual Bike Bike { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
