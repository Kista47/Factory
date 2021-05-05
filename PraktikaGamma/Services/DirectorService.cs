using Microsoft.EntityFrameworkCore;
using PraktikaGamma.Models;
using PraktikaGamma.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Services
{
    public class DirectorService
    {
        private readonly DepartmentRepository _departmentRepository;
        public DirectorService(DepartmentRepository departmentRepository)
        {
           _departmentRepository = departmentRepository;
        }

        //public async Task<IEnumerable<Department>> GetDepartments()
        //{
        //    return await _departmentRepository.GetDepartments();
        //}
    }
}
