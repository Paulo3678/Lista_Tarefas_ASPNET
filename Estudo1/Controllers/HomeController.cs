﻿using Estudo1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Estudo1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public void NovaTarefa([FromQuery] string tituloTarefa)
        {
            


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