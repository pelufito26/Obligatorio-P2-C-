using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class MiembroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}