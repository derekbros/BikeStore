using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeStoreApi.Repositories;
using BikeAgencyLibrary;

namespace BikeRentalAgency.Pages.Admin
{
    public class CartModel : PageModel
    {
        private IAgencyRepository repository;
        public CartModel(IAgencyRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

        }
        public IActionResult OnPost(long bikeId, string returnUrl)
        {
            Bike bike = repository.Bike.FirstOrDefault(p => p.BikeId == bikeId);
            Cart.AddItem(bike, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long bikeId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Bike.BikeId == bikeId).Bike);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}