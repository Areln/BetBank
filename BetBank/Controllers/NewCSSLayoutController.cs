using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BetBank.Controllers
{
    public class NewCSSLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}