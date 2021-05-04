using PraktikaGamma.DataBaseEntity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.DataBaseEntity.Bounds
{
    public class TaskAssembley
    {
        [Key, Column(Order = 0)]
        public int TaskId { get; set; }
        public DbDepartmentTask Task { get; set; }


        [Key, Column(Order = 1)]
        public int AssembleyId { get; set; }
        public DbAssembley Assembley { get; set; }

        public int AssembleyCount { get; set; }
    }
}

