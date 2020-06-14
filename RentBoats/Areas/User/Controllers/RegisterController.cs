using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentBoats.BAL.User;
using RentBoats.Model.User;
using RentBoats.Models.Filters;

namespace RentBoats.Areas.User.Controllers
{
    [SessionFilter]
    [Area("User")]
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
        public async Task<IActionResult> Register(AddBoat.AddBoatDetails model)
        {
            try
            {
                int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));

                var extension = Path.GetExtension(model.BoatImage.FileName);
                var size = extension.Length;

                if (!extension.ToLower().Equals(".jpg"))
                {
                    ModelState.AddModelError("Image", "File Extension  is not valid");
                }
                if (size > (5 * 1024 * 1024))
                {
                    ModelState.AddModelError("Image", "File size is bigger than 5MB");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var filename = model.BoatImage.FileName;
                string storePath = "wwwroot/UploadsImg/";
                if (model.BoatImage == null || model.BoatImage.Length == 0)
                {
                    ModelState.AddModelError("Image", "Please upload an image");
                    return View();
                }
                var path = "";
                DateTime dt = DateTime.Now;
                string newdt = dt.ToString("ddMMyyyhhmmss");
                path = Path.Combine(
                    Directory.GetCurrentDirectory(), storePath, userId + newdt + "-" + filename);
                model.BoatImagePath = storePath + userId + newdt + "-" + filename;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.BoatImage.CopyToAsync(stream);
                }
                model.UserId = userId;
                string result = BusinessUser.AddNewBoat(model);
                ModelState.Clear();
                ViewData["result"] = result;
            }
            catch(Exception ex)
            {

            }
            return View();
        }
    }
}