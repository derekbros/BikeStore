using BikeAgencyLibrary;
using BikeRentalAgency.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BikeStoreApi.Repositories;
using System.Linq;

namespace BikeRentalAgency.Controllers
{
    public class BikesController : Controller
    {
        private readonly IAgencyRepository repository;
        public int PageSize = 4;
        public BikesController(IAgencyRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(int bikePage = 1)

        {
            var model = new RentalsListViewModel
            {
                Bikes = (System.Collections.Generic.IList<Bike>)repository.Bike
        .OrderBy(p => p.BikeId)
        .Skip((bikePage - 1) * PageSize)
        .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = bikePage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Bike.Count()
                }
            };
            return View(model);
        }
        //public IActionResult Index()
        //{
        //    var model = new RentalsListViewModel();
        //    var rate = new RentalRate { RentalRateId = 1, DailyRate = 10, HourlyRate = 1 };

        //    model.Bikes.Add(new Bike { BikeId = 1, Rate = rate, Location = "NC", Size = "Large" });
        //    model.Bikes.Add(new Bike { BikeId = 2, Rate = rate, Location = "MO", Size = "Med" });
        //    model.Bikes.Add(new Bike { BikeId = 3, Rate = rate, Location = "NC", Size = "Small" });
        //    model.Bikes.Add(new Bike { BikeId = 4, Rate = rate, Location = "NC", Size = "Extra Medium" });
        //    model.Bikes.Add(new Bike { BikeId = 5, Rate = rate, Location = "NC", Size = "Large" });


        //    return View(model);
        //}
        public IActionResult Reserve(int? id)
        {
            return View();
        }

    }
}

