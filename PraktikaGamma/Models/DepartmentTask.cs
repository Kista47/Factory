using PraktikaGamma.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Models
{
    public class DepartmentTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Time { get; set; }

        public int? DepartmentId { get; set; }

        public ICollection<Assembley> Assemblies { get; set; } = new List<Assembley>();

        public DepartmentTask(int id, string name, string info, string time, int? departmentId, ICollection<Assembley> assemblies)
        {
            Id = id;
            Name = name;
            Info = info;
            Time = time;
            DepartmentId = departmentId;
            Assemblies = assemblies;
        }
    }
}
