using PraktikaGamma.DataBaseEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Models
{
    public class Detail
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Manual { get; set; }


        public Detail() { }
        public Detail(int id, string name, string info, string manual) : this(name, info, manual)
        {
            Id = id;
        }

        public Detail(string name, string info, string manual)
        {
            Name = name;
            Info = info;
            Manual = manual;
        }
    }
}
