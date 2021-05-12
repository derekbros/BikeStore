using BikeStoreApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BikeAgencyLibrary;

namespace BikeRentalAgency.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IAgencyRepository repository;
        public NavigationMenuViewComponent(IAgencyRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Bike
            .Select(x => x.TypeId)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}