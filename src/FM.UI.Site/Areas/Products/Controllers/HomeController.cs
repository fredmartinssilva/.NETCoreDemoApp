﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FM.UI.Site.Areas.Products.Controllers
{
    [Area("Products")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}