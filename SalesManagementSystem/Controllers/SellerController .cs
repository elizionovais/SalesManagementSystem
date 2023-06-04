using Microsoft.AspNetCore.Mvc;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Controllers
{
    public class SellerController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListSeller = new SellerModel().ListSellers();
            return View();
        }
        public IActionResult Register(int? id)
        {
            if(id != null)
            {
                ViewBag.Client = new SellerModel().GetSeller(id);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Register(SellerModel seller)
        {
            if (ModelState.IsValid)
            {
                seller.Save();
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(int id)
        {
            ViewData["DeleteId"] = id;
            return View();
        }

        public IActionResult DeleteSeller(int id)
        {
            new SellerModel().Delete(id);
            return View();
        }
    }
}
