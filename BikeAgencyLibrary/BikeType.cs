using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeAgencyLibrary
{
    public class BikeType
    {
        public int BikeTypeId { get; set; }
        public string BikeTypeName { get; set; }

        [NotMapped]
        public virtual Bike Bike { get; set; }
    }
}
