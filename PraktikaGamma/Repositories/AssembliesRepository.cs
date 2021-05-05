using PraktikaGamma.DataBaseEntity.Model;
using PraktikaGamma.Models;
using PraktikaGamma.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Repositories
{
    public class AssembliesRepository
    {
        EmployeeContext _dataBase;

        public async Task<Assembley> GetAssembleyById(int id)
        {
            return new Assembley(await _dataBase.Assemblies.FindAsync(id).ConfigureAwait(false));
        }

        public async Task<ICollection<Assembley>> GetAssembliesByTask(int TaskId)
        {
            var dbTask = await _dataBase.DepartmentTasks.FindAsync(TaskId).ConfigureAwait(false);

            _dataBase.Entry(dbTask).Collection(task => task.Assembleys).Load();

            return dbTask.Assembleys.Select(dbAssembley =>
            {
                return new Assembley(dbAssembley);
            }).ToArray();
        }
    }



}
