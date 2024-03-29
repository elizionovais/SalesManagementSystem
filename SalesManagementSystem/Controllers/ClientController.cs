﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Register(int? id)
        {
            if(id != null)
            {
                ViewBag.Client = new ClientModel().GetClient(id);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Register(ClientModel client)
        {
            if (ModelState.IsValid)
            {
                client.Save();
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
            new ClientModel().Delete(id);
            return View();
        }
    }
}
