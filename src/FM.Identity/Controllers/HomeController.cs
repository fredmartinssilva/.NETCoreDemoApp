using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FM.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using FM.Identity.Extensions;
using KissLog;

namespace FM.Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger logger)
        {
            this._logger = logger;
        }

        public IActionResult Index()
        {
            _logger.Warn("Warning message");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Policy = "Exclude")]
        public IActionResult AdminClaim()
        {
            return View("Admin");
        }

        [ClaimsAuthorize("Products", "Read")]
        public IActionResult AdminCustom()
        {
            return View("Admin");
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelError = new ErrorViewModel();

            if (id == 500)
            {
                modelError.Message = "Server Error! Try again or contact support.";
                modelError.Title = "Error";
                modelError.ErrorCode = id;
            }
            else if (id == 404)
            {
                modelError.Message = "Resource not found!";
                modelError.Title = "Resource not found";
                modelError.ErrorCode = id;
            }
            else if (id == 403)
            {
                modelError.Message = "Access denied!";
                modelError.Title = "Access denied";
                modelError.ErrorCode = id;
            }
            else
            {
                return StatusCode(400);
            }

            return View(modelError);
        }
    }
}
