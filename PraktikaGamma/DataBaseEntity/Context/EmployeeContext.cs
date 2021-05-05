using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PraktikaGamma.DataBaseEntity.Bounds;
using PraktikaGamma.DataBaseEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PraktikaGamma.Models.Context
{
    public class EmployeeContext : IdentityDbContext<User>
    {
        public DbSet<DbDepartment> Departments { get; set; }
        public DbSet<DbDepartmentTask> DepartmentTasks { get; set; }
        public DbSet<DbDetail> Details { get; set; }
        public DbSet<DbAssembley> Assemblies { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DbAssembley>()
                .HasMany(assembley => assembley.Details)
                .WithMany(detail => detail.Assemblies)
                .UsingEntity<AssembleyDetail>(
                   assembleyDetail => assembleyDetail

                            .HasOne(pt => pt.Detail)
                            .WithMany(t => t.AssembleyDetails)
                            .HasForeignKey(pt => pt.DetailId),

                   assembleyDetail => assembleyDetail

                            .HasOne(pt => pt.Assembley)
                            .WithMany(t => t.AssembleyDetails)
                            .HasForeignKey(pt => pt.AssembleyId),

                   assembleyDetail =>
                   {
                       assembleyDetail.HasKey(assemDetail => new { assemDetail.AssembleyId, assemDetail.DetailId });
                       assembleyDetail.ToTable("AssembleyDetails");
                   }
                );

            modelBuilder.Entity<DbAssembley>()
                .HasMany(task => task.Tasks)
                .WithMany(assem => assem.Assembleys)
                .UsingEntity<TaskAssembley>(
                   taskAssem => taskAssem

                            .HasOne(pt => pt.Task)
                            .WithMany(t => t.TaskAssembleys)
                            .HasForeignKey(pt => pt.TaskId),

                   taskAssem => taskAssem

                            .HasOne(pt => pt.Assembley)
                            .WithMany(t => t.TaskAssemblies)
                            .HasForeignKey(pt => pt.AssembleyId),

                   taskAssem =>
                   {
                       taskAssem.HasKey(assemDetail => new { assemDetail.TaskId, assemDetail.AssembleyId });
                       taskAssem.ToTable("TaskAssembley");
                   }
                );

            modelBuilder.Entity<AssembleySet>(entity =>
            {
                entity.HasKey(n => n.Id);

                entity.HasOne(assembley => assembley.MainAssembley)
                    .WithMany(ass => ass.MainAssembleys)
                    .HasForeignKey(ass => ass.MainAssembleyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(assembley => assembley.DerivativeAssembley)
                    .WithMany(ass => ass.DerivativeAssemblies)
                    .HasForeignKey(ass => ass.DerivativeAssembleyId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

