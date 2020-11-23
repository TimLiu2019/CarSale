using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarSale.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarSale.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

     

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("slide1"))
            {
                HttpContext.Response.Cookies.Append("slide1", "current");

            }
            if (Request.Cookies["slide1"] != null) {
                string cookie = Request.Cookies["slide1"];
                if (cookie.Equals("current")) {
                    ViewBag.Tree = "sequoia.png"; }
                else 
                {
                    ViewBag.Tree = "amg.jpg";
                } }
            else
            {
                ViewBag.Tree = "iris.png";
            }

            if (!HttpContext.Request.Cookies.ContainsKey("slide2"))
            {
                HttpContext.Response.Cookies.Append("slide2", "current");

            }
            if (Request.Cookies["slide2"] != null)
            {
            //    string cookie = Request.Cookies["slide2"];
            //    if (cookie.Equals("current"))
             //   {
             //       ViewBag.Tree2 = "2015A4.jpg";
             //   }
            //    else
              //  {
                    ViewBag.Tree2 = "2011-toyota-highlander.jpg";
              //  }
            }
            else
            {
                ViewBag.Tree2 = "civic.png";
            }

            if (!HttpContext.Request.Cookies.ContainsKey("slide3"))
            {
                HttpContext.Response.Cookies.Append("slide3", "current");

            }
            if (Request.Cookies["slide3"] != null)
            {
              //  string cookie = Request.Cookies["slide3"];
             //   if (cookie.Equals("current"))
              //  {
             //       ViewBag.Tree3 = "2015A4.jpg";
              //  }
              //  else
             //   {
                    ViewBag.Tree3 = "2017hyundai-elantra.jpg";
              //  }
            }
            else
            { 
                ViewBag.Tree3 = "sequoia.png";
            }


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        public IActionResult Manage()
        {
            //  return View();
            return Redirect("/carModels/Index");
        }

        public IActionResult Images()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
