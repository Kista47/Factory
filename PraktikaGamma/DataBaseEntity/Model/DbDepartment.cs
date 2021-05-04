using PraktikaGamma.DataBaseEntity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.DataBaseEntity.Model
{
    public class DbDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Chief { get; set; }
        public virtual List<DbDepartmentTask> DepTasks { get; set; } = new List<DbDepartmentTask>();
    }
}
