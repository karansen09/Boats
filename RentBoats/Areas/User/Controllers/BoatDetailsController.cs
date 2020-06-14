using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentBoats.BAL.User;
using RentBoats.Model.User;
using RentBoats.Models.Filters;

namespace RentBoats.Areas.User.Controllers
{
    [SessionFilter]
    [Area("User")]
    public class BoatDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BoatDetails()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetBoatDetails()
        {
            int userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            List<AddBoat.AddBoatDetails> mylist = new List<AddBoat.AddBoatDetails>();
            mylist = BusinessUser.boatList(userid);
            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(mylist),
                ContentType = "application/json"
            };
            return jsonResult;
        }

        public IActionResult GetBoatDetailsRent(ModelRentBoat model)
        {
            if(model.RentId !=null)
            {
                int myresponse = BusinessUser.StopRent(model);
                return StatusCode(200, myresponse);
            }
            string result=BusinessUser.NewRent(model);
            if (result == "-1")
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { Message = "-1" });
            }
            return Json("ok");
        }

        public IActionResult RemoveBoat(string id)
        {
            if(id.Contains(","))
            {
                foreach (var item in id.Split(','))
                {
                    BusinessUser.Remove(Convert.ToInt32(item));
                }
            }
            else
            {
                BusinessUser.Remove(Convert.ToInt32(id));
            }
            
            return Json("ok");
        }
    }
}