using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PraktikaGamma.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Controllers
{
    //[Authorize(Roles = "Director")]
    public class DirectorController : Controller
    {
        private readonly DirectorService _directorService;

        public DirectorController(DirectorService directorService)
        {
            _directorService = directorService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
