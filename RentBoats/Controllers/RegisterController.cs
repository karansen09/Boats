using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentBoats.BAL.User;
using RentBoats.Model.User;

namespace RentBoats.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(ModelRegisterNewUser model)
        {
            if(!ModelState.IsValid)
            {
                ViewData["Result"] = "Please enter details correctly";
                return View(model);
            }
            ModelState.Clear();
            string result = BusinessUser.RegisterNewUser(model);
            ViewData["Result"] = result;
            return View();
        }
    }
}