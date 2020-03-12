using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Data;
using MusicShop.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicShop.Controllers
{
    public class CustomerCartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string returnUrl, CustomerCart cart)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public async Task<RedirectToActionResult> AddToCart(int? id, string returnUrl)
        {
            var guitar = await _context.Guitar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitar != null)
            {
                CustomerCart cart = new CustomerCart();
                cart.AddGuitar(guitar);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}