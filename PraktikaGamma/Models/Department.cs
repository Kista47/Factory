using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Models
{
    public class Department
    {
        public int Id { get; }



        [Required(ErrorMessage = "Введите название отдела")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите Имя Заведующего отделом")]
        public string Chief { get; set; }

        public virtual List<DepartmentTask> DepTasks { get; set; } = new List<DepartmentTask>();

        public Department() { }

        public Department(string name, string chief)
        {
            Name = name;
            Chief = chief;
        }

        public Department(int id, string name, string chief) : this(name, chief)
        {
            Id = id;
        }

    }
}
