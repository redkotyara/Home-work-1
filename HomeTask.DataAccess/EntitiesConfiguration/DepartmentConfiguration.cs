using System.Data.Entity;
using HomeTask.DataAccess.Entities;

namespace HomeTask.DataAccess.EntitiesConfiguration
{
    public static class DepartmentConfiguration
    {
        public static void ConfigureDepartmentEntity(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentEntity>()
                .ToTable("Departments")
                .HasKey(x => x.DepartmentId);
        } 
    }
}