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
        public string Manual { get; set; }
        public int Time { get; set; }

        public List<Detail> Details { get; set; } = new List<Detail>();
        public virtual List<Assembley> Assembleys { get; set; } = new List<Assembley>();

        public Assembley() { }
        public Assembley(string name, int time, string info)
        {
            Name = name;
            Manual = info;
            Time = time;
        }
        public Assembley(int id, string name, string info, int time) : this(name, time, info)
        {
            Id = id;
        }
        public Assembley(DbAssembley dbAssembley)
        {
            Id = dbAssembley.Id;
            Name = dbAssembley.Name;
            Manual = dbAssembley.Info;
            Time = dbAssembley.Time;
        }

        public Assembley(int id, string name, string info, int time, List<Detail> details, List<Assembley> assembleys) : this(id, name, info, time)
        {
            Details = details;
            Assembleys = assembleys;
        }
    }
}
