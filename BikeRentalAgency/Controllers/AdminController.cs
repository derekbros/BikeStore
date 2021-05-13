using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeRentalAgency.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BikeRentalAgency.Models;
using BikeRentalAgency.Repositories;
using BikeAgencyLibrary;

namespace BikeRentalAgency.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBikeRentalRepository _bikeRentalRepository;

        public AdminController(IBikeRentalRepository bikeRentalrepository)
        {
            _bikeRentalRepository = bikeRentalrepository;
        }

        public ViewResult Inventory()
        {
            
            return View();
        }
    }
}
