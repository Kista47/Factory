using PraktikaGamma.DataBaseEntity.Bounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.DataBaseEntity.Model
{
    public class DbDepartmentTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Time { get; set; }

        public int? DepartmentId { get; set; }

        public List<TaskAssembley> TaskAssembleys = new List<TaskAssembley>();

        public List<DbAssembley> Assembleys = new List<DbAssembley>();
    }
}
