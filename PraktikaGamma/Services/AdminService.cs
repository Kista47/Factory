using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PraktikaGamma.Models;
using PraktikaGamma.Repositories;

namespace PraktikaGamma.Services
{
    public class AdminService
    {
        private DepartmentRepository _departmentRepository;

        public AdminService(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task CreateDepartment(Department department)
        {
            await _departmentRepository.CreateDepartment(department).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _departmentRepository.GetDepartments().ConfigureAwait(false);
        }


    }
}
