using System.Linq;
using Microsoft.EntityFrameworkCore;
using BikeAgencyLibrary;


using BikeStoreApi.Models;

namespace BikeStoreApi.Repositories
{
    public class EFRentalRepository : IRentalRepository
    {
        private BikeRentalContext context;

        public EFRentalRepository(BikeRentalContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Rental> Rentals => context.Rentals
       .Include(o => o.Lines)
       .ThenInclude(l => l.Bike);
        public void SaveRental(Rental rental)
        {
            context.AttachRange(rental.Lines.Select(l => l.Bike));
            if (rental.RentalId == 0)
            {
                context.Rentals.Add(rental);
            }
            context.SaveChanges();

        }
    }
}

