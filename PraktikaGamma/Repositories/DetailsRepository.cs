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


    }
}
