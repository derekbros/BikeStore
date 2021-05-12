using BikeRentalAgency.Models.ViewModels;
using BikeAgencyLibrary;
using BikeStoreApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAgencyRepository repository;
        public int PageSize = 4;
        public HomeController(IAgencyRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(int productPage = 1)

        {
            var model = new RentalsListViewModel
            {
                Bikes = (System.Collections.Generic.IList<Bike>)repository.Bike
        .OrderBy(p => p.BikeId)
        .Skip((productPage - 1) * PageSize)
        .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Bike.Count()
                }
            };
            return View(model);
        }

    }
}
