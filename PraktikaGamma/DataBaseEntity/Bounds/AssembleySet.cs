using PraktikaGamma.DataBaseEntity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.DataBaseEntity.Bounds
{
    public class AssembleySet
    {
        public int Id { get; set; }

        [ForeignKey("MainAssembleyId"), Column(Order = 0)]
        public int MainAssembleyId { get; set; }
        public DbAssembley MainAssembley { get; set; }

        [ForeignKey("DerivativeAssembleyId"), Column(Order = 1)]
        public int DerivativeAssembleyId { get; set; }
        public DbAssembley DerivativeAssembley { get; set; }

        public int DerativeAssemCount { get; set; }
    }
}
