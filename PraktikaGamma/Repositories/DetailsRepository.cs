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
    public class DetailsRepository
    {
        private EmployeeContext _dataBase;

        public DetailsRepository(EmployeeContext context)
        {
            _dataBase = context;
        }

        public async Task<IReadOnlyCollection<Detail>> GetDetailsByAssembleyId(int AssembleyId)
        {
            var dbDetails = await _dataBase.Assemblies.FindAsync(AssembleyId).ConfigureAwait(false);

            return dbDetails.Details.Select(dbDetail =>
            {
                return new Detail(dbDetail.Id, dbDetail.Name, dbDetail.Info, dbDetail.Manual);
            }).ToArray();
        }

        public async Task<IReadOnlyCollection<Detail>> GetDetails()
        {
            var dbDetails = await _dataBase.Details.OrderBy(detail => detail.Name).ToArrayAsync().ConfigureAwait(false);

            return dbDetails.Select(detail =>
            {
                return new Detail
                {
                    Name = detail.Name,
                    Info = detail.Info,
                    Manual = detail.Manual
                };
            }).ToArray();
        }

        public async Task CreateDetail(Detail detail)
        {
            await  _dataBase.Details.AddAsync(TransformToDbDetail(detail)).ConfigureAwait(false);
            await _dataBase.SaveChangesAsync().ConfigureAwait(false);
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

        public async Task<Detail> GetDetailById(int id)
        {
            var dbDetail = await _dataBase.Details.FindAsync(id).ConfigureAwait(false);
            return new Detail(id, dbDetail.Name, dbDetail.Info, dbDetail.Manual);
        }



    }
}
