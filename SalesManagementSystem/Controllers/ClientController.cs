using Microsoft.AspNetCore.Mvc;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListClient = new ClientModel().ListClients();
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(ClientModel client)
        {
            if (ModelState.IsValid)
            {
                client.Insert();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
