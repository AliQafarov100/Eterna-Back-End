using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eterna_Back_End.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eterna_Back_End.Areas.EternaAdmin.Controllers
{

    public class DashBoardController : Controller
    {
        [Area("EternaAdmin")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
