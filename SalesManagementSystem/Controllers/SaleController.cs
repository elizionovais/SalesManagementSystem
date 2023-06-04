using Microsoft.AspNetCore.Http;
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
        private HttpContextAccessor httpContextAcessor;

        public SaleController(HttpContextAccessor httpContext)
        {
            httpContextAcessor = httpContext;
        }

        public IActionResult Index()
        {
            ViewBag.ListSales = new SaleModel().ListSales();
            return View();
        }
        public IActionResult Register()
        {
            LoadData();
            return View();
        }
        [HttpPost]
        public IActionResult Register(SaleModel sale)
        {
            sale.Seller_Id = httpContextAcessor.HttpContext.Session.GetString("IdUser");
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
