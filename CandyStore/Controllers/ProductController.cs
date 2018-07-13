using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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


        public IActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Product p = _candyStoreDbContext.Products.Find(id.Value);
                return View(p);
            }
            return NotFound();

            
            
        }

        
    }
}