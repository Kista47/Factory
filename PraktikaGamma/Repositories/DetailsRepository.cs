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


    }
}
