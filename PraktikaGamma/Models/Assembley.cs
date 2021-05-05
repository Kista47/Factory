using PraktikaGamma.DataBaseEntity.Bounds;
using PraktikaGamma.DataBaseEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Models
{
    public class Assembley
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int Time { get; set; }

        public List<Detail> Details { get; set; } = new List<Detail>();
        public virtual List<Assembley> Assembleys { get; set; } = new List<Assembley>();

        public Assembley(int id, string name, string info, int time)
        {
            Id = id;
            Name = name;
            Info = info;
            Time = time;
        }

        public Assembley(DbAssembley dbAssembley)
        {
            Id = dbAssembley.Id;
            Name = dbAssembley.Name;
            Info = dbAssembley.Info;
            Time = dbAssembley.Time;
        }

    }
}
