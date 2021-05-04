using PraktikaGamma.DataBaseEntity.Model;
using PraktikaGamma.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.DataBaseEntity.Bounds
{
    public class AssembleyDetail
    {
        [Key, Column(Order = 0)]
        public int DetailId { get; set; }
        public DbDetail Detail { get; set; }

        [Key, Column(Order = 1)]
        public int AssembleyId { get; set; }
        public DbAssembley Assembley { get; set; }

        public int DetailCount { get; set; }
    }
}
