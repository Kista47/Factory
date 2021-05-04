using Microsoft.EntityFrameworkCore;
using PraktikaGamma.Models;
using PraktikaGamma.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Repositories
{
    public class DepartmentRepository
    {
        private EmployeeContext _dataBase;

        public DepartmentRepository(EmployeeContext context)
        {
            _dataBase = context;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var dbDepartments = await _dataBase.Departments.OrderBy(department => department.Name).ToArrayAsync().ConfigureAwait(false);

            return dbDepartments.Select(department =>
            {
                return new Department(department.Id,
                                      department.Name,
                                      department.Chief);
            }).ToList();
        }
    }
}
