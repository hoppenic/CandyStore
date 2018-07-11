using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CandyStore.Models;

namespace CandyStore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //responds on GET
        public IActionResult Register()
        {
            return View();
        }

        //responds on POST /account/register

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string username, string password)
        {

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
          
           
        }





    }





  

}