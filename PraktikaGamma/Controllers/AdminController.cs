using Microsoft.AspNetCore.Mvc;
using PraktikaGamma.Models;
using PraktikaGamma.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Controllers
{
    public class AdminController : Controller
    {
        private AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DepartmentMenu()
        {
            return View(await _adminService.GetDepartments());
        }

        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View(new Department());
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(Department department)
        {
            await _adminService.CreateDepartment(department);
            return RedirectToRoute(new {controller = "Admin", action = "DepartmentMenu"});
        }

    }
}
