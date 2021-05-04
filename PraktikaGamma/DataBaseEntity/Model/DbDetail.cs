using PraktikaGamma.DataBaseEntity.Bounds;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.DataBaseEntity.Model
{
    public class DbDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Manual { get; set; }
        public List<AssembleyDetail> AssembleyDetails { get; set; } = new List<AssembleyDetail>();
        public List<DbAssembley> Assemblies { get; set; } = new List<DbAssembley>();
    }
}
