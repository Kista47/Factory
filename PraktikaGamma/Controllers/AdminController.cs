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
            return View(await _adminService.GetDepartments().ConfigureAwait(false));
        }


        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View(new Department());
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(Department department)
        {
            await _adminService.CreateDepartment(department).ConfigureAwait(false);
            return RedirectToRoute(new {controller = "Admin", action = "DepartmentMenu"});
        }

        public async Task<IActionResult> AssembliesMenu()
        {
            return View(await _adminService.GetAssembleys().ConfigureAwait(false));
        }

        [HttpGet]
        public IActionResult CreateAssembley()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssembley(Assembley assembley, int[] detailsId, int[] detailsCounts)
        {
            await _adminService.CreateAssembley(assembley, detailsId, detailsCounts).ConfigureAwait(false);
            return RedirectToRoute(new { controller = "Admin", action = "AssembliesMenu" });
        }

        public async Task<IActionResult> DetailsMenu()
        {
            return View(await _adminService.GetDetails().ConfigureAwait(false));
        }

        [HttpGet]
        public IActionResult CreateDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetail(Detail detail)
        {
            await _adminService.CreateDetail(detail);
            return RedirectToRoute(new { controller = "Admin", action = "DetailsMenu" });
        }

        [HttpPost("/AdminController/AddDetailById")]
        public async Task<JsonResult> AddDetailById(int id)
        {
            return new JsonResult(await _adminService.GetDetailById(id).ConfigureAwait(false));
        }

        [HttpPost("/AdminController/DeleteDetailFromAssem")]
        public async Task<IActionResult> DeleteDetailFromAssem(int id)
        {
            return new JsonResult("");
        }

    }
}
