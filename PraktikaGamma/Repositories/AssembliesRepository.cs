using Microsoft.EntityFrameworkCore;
using PraktikaGamma.DataBaseEntity.Bounds;
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
        private DetailsRepository _detailsRepository;

        public AssembliesRepository(EmployeeContext dataBase, DetailsRepository detailsRepository)
        {
            _dataBase = dataBase;
            _detailsRepository = detailsRepository;
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

        public async Task CreateAssembley(Assembley assembley, int[] detailsId, int[] detailsCounts)
        {
            var dbAssembley = TransformAssembley(assembley);
            for (int i = 0; i < detailsId.Length; i++)
            {


                dbAssembley.AssembleyDetails.Add(new AssembleyDetail() { Detail = await _detailsRepository.GetDbDetailById(detailsId[i]), DetailCount = detailsCounts[0] });
            }

            await _dataBase.Assemblies.AddAsync(dbAssembley).ConfigureAwait(false);
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
        public DbDetail TransformToDbDetail(Detail detail)
        {
            return new DbDetail()
            {
                Name = detail.Name,
                Info = detail.Info,
                Manual = detail.Manual
            };
        }

    }
}
