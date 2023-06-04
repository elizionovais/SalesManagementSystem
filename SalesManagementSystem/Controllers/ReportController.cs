using Microsoft.AspNetCore.Mvc;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Sales()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sales(ReportModel report)
        {
            if(report.FirstDate.Year == 1)
            {
            ViewBag.ListSales = new SaleModel().ListSales();
            }
            else
            {
                string initial = report.FirstDate.ToString("yyyy/MM/dd");
                string final = report.FinalDate.ToString("yyyy/MM/dd");
                ViewBag.ListSales = new SaleModel().ListSales(initial, final);
            }
            return View();
        }
  
        public IActionResult Commissions()
        {
            return View();
        }
    }
}
