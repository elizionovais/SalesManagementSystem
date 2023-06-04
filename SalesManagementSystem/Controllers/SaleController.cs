using Microsoft.AspNetCore.Mvc;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Register()
        {
            LoadData();
            return View();
        }
        [HttpPost]
        public IActionResult Register(SaleModel sale)
        {
            sale.Insert();
            LoadData();
            return View();
        }

        public void LoadData()
        {
            ViewBag.ListClients = new SaleModel().ReturnListClients();
            ViewBag.ListSellers = new SaleModel().ReturnListSellers();
            ViewBag.ListProducts = new SaleModel().ReturnListProducts();
        }
    }
}
