using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzzaOrderingFEApplication.Controllers
{
    public class StartUpPageController : Controller
    {
        public IActionResult StartPage()
        {
            return View();
        }
    }
}
