using BikeAgencyLibrary;
using BikeRentalAgency.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BikeStoreApi.Repositories;
using System.Linq;
using BikeRentalAgency.Repositories;
using System.Collections.Generic;

namespace BikeRentalAgency.Controllers
{
    public class BikesController : Controller
    {
        private readonly IBikeRentalRepository repository;
        public int PageSize = 4;
        public BikesController(IBikeRentalRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(int bikePage = 1)

        {
          
            return View(new RentalsListViewModel());
        }
        //public IActionResult GetBikes()
        //{
        //    Bike b = new Bike();
        //    List<Bike> bike = new List<Bike>();
        //    bike = b.
        //}
        public IActionResult Reserve(int? id)
        {
            return View();
        }

    }
}

