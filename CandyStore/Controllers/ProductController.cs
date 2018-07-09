using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CandyStore.Controllers
{
    public class ProductController : Controller
    {

        private List<Product> _products;


        //this is a constructor
        public ProductController()
        {
            //using hard coded data for now to mock up prods

            _products = new List<Product>();
            _products.Add(new Product
            {

                ID=1,
                Name="Chocolate Bar",
                Description="Dark Chocolate",
                Image="",
                Price=3.99m


            });

            _products.Add(new Product
            {

                ID = 2,
                Name = "Gummy Bears",
                Description = "Various Flavors of Gummy Bears",
                Image = "",
                Price = 5.99m




            });

        }
        public IActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Product p = _products.Single(x => x.ID == id.Value);
                return View(p);
            }
            return NotFound();

            
            return View(_products);
        }

        public IActionResult Index()
        {
            return View(_products);
        }
    }
}