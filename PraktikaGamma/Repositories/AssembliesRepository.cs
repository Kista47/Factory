using Microsoft.EntityFrameworkCore;
using PraktikaGamma.DataBaseEntity.Model;
using PraktikaGamma.Models;
using PraktikaGamma.Models.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Repositories
{
    public class AssembliesRepository
    {
        private EmployeeContext _dataBase;

        public AssembliesRepository(EmployeeContext dataBase)
        {
            _dataBase = dataBase;
        }

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

        public async Task<IReadOnlyCollection<Assembley>> GetAssembleys()
        {
            var dbAssems = await _dataBase.Assemblies.OrderBy(assem => assem.Name).ToArrayAsync().ConfigureAwait(false);

            return dbAssems.Select(assem =>
            {
                return new Assembley(assem);
            }).ToArray();
        }

        public async Task CreateAssembley(Assembley assembley)
        {
            await _dataBase.Assemblies.AddAsync(TransformAssembley(assembley)).ConfigureAwait(false);
            await _dataBase.SaveChangesAsync().ConfigureAwait(false);
        }

        public DbAssembley TransformAssembley(Assembley assembley)
        {
            return new DbAssembley
            {
                Name = assembley.Name,
                Time = assembley.Time,
                Info = assembley.Manual
            };
        }

    }
}
