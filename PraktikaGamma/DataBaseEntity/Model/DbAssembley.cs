using PraktikaGamma.DataBaseEntity.Bounds;
using PraktikaGamma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.DataBaseEntity.Model
{
    public class DbAssembley
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int Time { get; set; }

        public List<DbDetail> Details { get; set; } = new List<DbDetail>();
        public List<AssembleyDetail> AssembleyDetails { get; set; } = new List<AssembleyDetail>();

        public virtual List<AssembleySet> MainAssembleys { get; set; } = new List<AssembleySet>();
        public virtual List<AssembleySet> DerivativeAssemblies { get; set; } = new List<AssembleySet>();

        public virtual List<DbDepartmentTask> Tasks { get; set; } = new List<DbDepartmentTask>();
        public List<TaskAssembley> TaskAssemblies { get; set; } = new List<TaskAssembley>();

        public DbAssembley(Assembley assembley)
        {
            Id = assembley.Id;
            Name = assembley.Name;
            Info = assembley.Manual;
            Time = assembley.Time;
        }

        public DbAssembley(int id, string name, string info, int time)
        {
            Id = id;
            Name = name;
            Info = info;
            Time = time;
        }

        public DbAssembley() { }
    }
}
