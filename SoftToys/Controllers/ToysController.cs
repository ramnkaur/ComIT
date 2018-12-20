using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SoftToys.Controllers
{
    public class ToysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}