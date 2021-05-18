using Microsoft.AspNetCore.Identity;
using PraktikaGamma.DataBaseEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Models
{
    public class User : IdentityUser
    {
        public int? DbDepartmentId { get; set; }
        public DbDepartment Department { get; set; }

    }
}
