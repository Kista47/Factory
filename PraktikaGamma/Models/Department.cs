using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Models
{
    public class Department
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Chief { get; set; }

        public virtual List<DepartmentTask> DepTasks { get; set; } = new List<DepartmentTask>();

        public Department(int id, string name, string chief)
        {
            Id = id;
            Name = name;
            Chief = chief;
        }
    }
}
