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

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}