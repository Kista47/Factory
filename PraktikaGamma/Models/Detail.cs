using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Manual { get; set; }

        public Detail(int id, string name, string info, string manual)
        {
            Id = id;
            Name = name;
            Info = info;
            Manual = manual;
        }
    }
}
