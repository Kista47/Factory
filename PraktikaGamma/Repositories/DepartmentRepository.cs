using Microsoft.EntityFrameworkCore;
using PraktikaGamma.DataBaseEntity.Model;
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

        public async Task CreateDepartment(Department department)
        {
            await _dataBase.AddAsync(TransformDepartment(department)).ConfigureAwait(false);
            await _dataBase.SaveChangesAsync().ConfigureAwait(false);
        }

        public DbDepartment TransformDepartment(Department department)
        {
            return new DbDepartment
            {
                Name = department.Name,
                Chief = department.Chief
            };
        }
    }
}
