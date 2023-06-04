using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Login(int? id)
        {
            //Para realizar o logout
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("IdUser", string.Empty);
                    HttpContext.Session.SetString("NameUser", string.Empty);
                }
            }
            //Fim

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                bool loginOk = login.ValidateLogin();
                if (loginOk)
                {
                    HttpContext.Session.SetString("IdUser", login.Id);
                    HttpContext.Session.SetString("NameUser", login.Name);
                    return RedirectToAction("Menu", "Home");
                }
                else
                {
                    TempData["ErrorLogin"] = "Invalid Credentials!";
                }
            }

            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
