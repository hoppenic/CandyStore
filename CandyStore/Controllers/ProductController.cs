using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CandyStore.Controllers
{
    public class ProductController : Controller
    {


        private readonly CandyStoreDbContext _candyStoreDbContext;

        //this is a constructor, injecting in an instance of candystoredbcontext
        public ProductController(CandyStoreDbContext candyStoreDbContext)
        {

            _candyStoreDbContext = candyStoreDbContext;



        }

        public IActionResult Index()
        {
            //a list, called products of our Product class
            List<Product> products = _candyStoreDbContext.Products.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Details(int? id,int quantity=1)
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
                cartId = Guid.NewGuid();
                cart.CookieIdentifier = cartId;

                _candyStoreDbContext.Carts.Add(cart);
                Response.Cookies.Append("cartId", cartId.ToString(), new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.UtcNow.AddYears(100) });
            }

            CartItem item = cart.CartItems.FirstOrDefault(x => x.Product.ID == id);
            if (item == null)
            {
                item = new CartItem();
                item.Product = _candyStoreDbContext.Products.Find(id);
                cart.CartItems.Add(item);
            }

            item.Quantity += quantity;
            cart.LastModified = DateTime.Now;

            _candyStoreDbContext.SaveChanges();
            return RedirectToAction("Index", "Cart");

            
            
        }

        
    }
}