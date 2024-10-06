using System.Data.Entity;
using HomeTask.DataAccess.Entities;

namespace HomeTask.DataAccess.EntitiesConfiguration
{
    public static class EmployeeExperienceConfiguration
    {
        public static void ConfigureEmployeeExperienceConfiguration(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeExperienceEntity>()
                .ToTable("EmployeeExperiences")
                .HasKey(x => new { x.EmployeeId, x.ProgramingLanguageId });
            
            modelBuilder.Entity<EmployeeExperienceEntity>()
                .HasRequired(ee => ee.Employee)
                .WithMany(e => e.Experiences)
                .HasForeignKey(ee => ee.EmployeeId);
            
            modelBuilder.Entity<EmployeeExperienceEntity>()
                .HasRequired(ee => ee.ProgramingLanguage)
                .WithMany(pl => pl.Employees)
                .HasForeignKey(ee => ee.ProgramingLanguageId);
        }
    }
}