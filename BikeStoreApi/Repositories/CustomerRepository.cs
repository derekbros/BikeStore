using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStoreApi.Models;
using BikeAgencyLibrary;

namespace BikeStoreApi.Repositories
{
    public class CustomerRepository
    {
        IQueryable<Bike> Bike { get; }
        IQueryable<BikeTypesId> BikeType { get; }
        IQueryable<PaymentStatus> PaymentStatus { get; }
        IQueryable<RentalDetail> RentalDetail { get; }
        IQueryable<Rental> Rental { get; }
    }
}