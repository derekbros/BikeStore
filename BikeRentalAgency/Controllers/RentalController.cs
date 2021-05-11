using BikeRentalAgency.Models;
using Microsoft.AspNetCore.Mvc;
using BikeAgencyLibrary;
using BikeStoreApi.Repositories;
using System.Linq;


namespace BikeRentalAgency.Controllers
{
    public class RentalController : Controller
    {
        private IRentalRepository repository;
        private Cart cart;
        public RentalController(IRentalRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }
        public ViewResult Checkout() => View(new Rental());
        [HttpPost]
        public IActionResult Checkout(Rental rental)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                rental.Lines = cart.Lines.ToArray();
                repository.SaveRental(rental);
                cart.Clear();
                return RedirectToPage("/Completed", new { RentalId = rental.RentalId });
            }
                return View();
            
        }
    }
}

