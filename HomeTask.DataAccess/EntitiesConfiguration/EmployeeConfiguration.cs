using System.Data.Entity;
using HomeTask.DataAccess.Entities;

namespace HomeTask.DataAccess.EntitiesConfiguration
{
    public static class EmployeeConfiguration
    {
        public static void ConfigureEmployeeEntity(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeEntity>()
                .ToTable("Employees")
                .HasKey(e => e.EmployeeId)
                .HasRequired(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);
            
            modelBuilder.Entity<EmployeeEntity>()
                .HasRequired(e => e.Gender)
                .WithMany(g => g.Employees)
                .HasForeignKey(e => e.GenderId);
        }
    }
}