using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeAgencyLibrary;

namespace BikeStoreApi.Repositories
{
    public interface IRentalRepository
    {
        IQueryable<Rental> Rentals { get; }
        void SaveRental(Rental rental);
    }
}
