using System.Data.Entity;
using HomeTask.DataAccess.Entities;

namespace HomeTask.DataAccess.EntitiesConfiguration
{
    public static class GenderConfiguration
    {
        public static void ConfigureGenderEntity(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenderEntity>()
                .ToTable("Genders")
                .HasKey(p => p.GenderId);
        }
    }
}