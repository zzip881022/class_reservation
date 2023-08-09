using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reservation_new.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace reservation_new.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public ViewResult ReserveForm()
        {
            return View();
        }

        public ViewResult ShowList()
        {
            return View(Repository.Responses);
        }


        [HttpPost]
        public ViewResult ReserForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddRepository(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                return View("ReserveForm", guestResponse);
            }

        }

    }
}
