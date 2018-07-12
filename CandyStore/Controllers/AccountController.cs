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
        SignInManager<CandyStoreUser> _signInManager;

        public AccountController(SignInManager<CandyStoreUser> signInManager)
        {
            _signInManager = signInManager;


        }
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
        public IActionResult Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                CandyStoreUser newUser = new CandyStoreUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber
                };

                IdentityResult creationResult = _signInManager.UserManager.CreateAsync(newUser).Result;

                if (creationResult.Succeeded)
                {
                    IdentityResult passwordResult = _signInManager.UserManager.AddPasswordAsync(newUser, model.Password).Result;
                    if (passwordResult.Succeeded)
                    {
                        _signInManager.SignInAsync(newUser, false).Wait();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach(var error in passwordResult.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                    }
                }
                else
                {
                    foreach (var error in creationResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }

            }
            return View();
          
           
        }

        public IActionResult SignOut()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }

        //get
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignInViewModel model)
        {

            if (ModelState.IsValid)
            {
                CandyStoreUser existingUser = _signInManager.UserManager.FindByNameAsync(model.UserName).Result;
                if(existingUser != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult passwordResult = _signInManager.CheckPasswordSignInAsync(existingUser, model.Password, false).Result;
                    if (passwordResult.Succeeded)
                    {
                        _signInManager.SignInAsync(existingUser, false).Wait();

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("PasswordIncorrect", "Username or password incorrect");
                    }
                }
                else
                {
                    ModelState.AddModelError("UserDoesNotExist", "Username does not exist!");
                }
                
            }

            return View();
        }

       




    }





  

}