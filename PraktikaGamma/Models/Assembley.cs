﻿using PraktikaGamma.DataBaseEntity.Bounds;
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

        public virtual List<AssembleySet> MainAssembleys { get; set; } = new List<AssembleySet>();
        public virtual List<AssembleySet> DerivativeAssemblies { get; set; } = new List<AssembleySet>();

        public virtual List<DepartmentTask> Tasks { get; set; } = new List<DepartmentTask>();
        public List<TaskAssembley> TaskAssemblies { get; set; } = new List<TaskAssembley>();

        public Assembley(int id, string name, string info, int time)
        {
            Id = id;
            Name = name;
            Info = info;
            Time = time;
        }
    }
}