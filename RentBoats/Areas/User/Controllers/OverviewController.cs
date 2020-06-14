using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentBoats.Models.Filters;

namespace RentBoats.Areas.User.Controllers
{
    [SessionFilter]
    [Area("User")]
    public class OverviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Overview()
        {
            return View();
        }
    }
}