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
    public class DepartmentTaskRepository
    {
        private EmployeeContext _dataBase;

        public DepartmentTaskRepository(EmployeeContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task<IReadOnlyCollection<DepartmentTask>> GetTask(int departmentTaskId)
        {
            var dbTasks = await _dataBase.DepartmentTasks.Where(task => task.DepartmentId == departmentTaskId)
                                                   .OrderBy(task => task.Name)
                                                   .ToArrayAsync()
                                                   .ConfigureAwait(false);

            return dbTasks.Select(task =>
            {
                return new DepartmentTask(task.Id,
                                          task.Name,
                                          task.Info,
                                          task.Time,
                                          departmentTaskId,
                                          GetTaskAssembleys(task));
            }).ToArray();
        }

        public ICollection<Assembley> GetTaskAssembleys(DbDepartmentTask dbDepartmentTask)
        {
            _dataBase.Entry(dbDepartmentTask).Collection(task => task.Assembleys).Load();

            return dbDepartmentTask.Assembleys.Select(dbAssembley =>
            {
                return new Assembley(dbAssembley.Id, dbAssembley.Name, dbAssembley.Info, dbAssembley.Time);
            }).ToArray();
        }

    }
}
