using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentBoats.BAL.User;
using RentBoats.Model.User;
using RentBoats.Models.Filters;

namespace RentBoats.Controllers
{
    public class LogonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logon()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Logon(Login model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                List<Login> logins = new List<Login>();
                logins = BusinessUser.GetLogins(model);
                if(logins[0].RoleId==0)
                {
                    ModelState.AddModelError("user", "Invalid Credentials");
                    return View(model);
                }
                if(logins.Count>0)
                {
                    HttpContext.Session.SetString("UserName", logins[0].Username);
                    HttpContext.Session.SetString("UserId", logins[0].Id);
                    HttpContext.Session.SetObject("UserDetails", logins);
                    return RedirectToAction("Overview", "Overview", new { Area = "User" });
                }
            }
            return View();
        }
        
    }
}