using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CandyStore.Models;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.Controllers
{
    public class CartController : Controller
    {
        //private instance of class CandyStoreDbContext
        private readonly CandyStoreDbContext _candyStoreDbContext;

        //constructor injecting _candyStoreDbContext using an instance of candyStoreDbContext
        public CartController(CandyStoreDbContext candyStoreDbContext)
        {
            _candyStoreDbContext = candyStoreDbContext;
        }
      
        public IActionResult Index()
        {

            Guid cartId;
            Cart cart = null;
            if (Request.Cookies.ContainsKey("cartId"))
            {
                if(Guid.TryParse(Request.Cookies["cartId"],out cartId))
                {
                    cart = _candyStoreDbContext.Carts
                        .Include(Carts => Carts.CartItems)
                        .ThenInclude(CartItems => CartItems.Product)
                        .FirstOrDefault(x => x.CookieIdentifier == cartId);
                }
            }
            if (cart == null)
            {
                cart = new Cart();
            }

            return View(cart);
        }
    }
}