using Microsoft.AspNetCore.Mvc;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListProduct = new ProductModel().ListProducts();
            return View();
        }
        public IActionResult Register(int? id)
        {
            if(id != null)
            {
                ViewBag.Product = new ProductModel().GetProduct(id);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Register(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                product.Save();
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(int id)
        {
            ViewData["DeleteId"] = id;
            return View();
        }

        public IActionResult DeleteClient(int id)
        {
            new ProductModel().Delete(id);
            return View();
        }
    }
}
