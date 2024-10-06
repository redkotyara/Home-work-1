using System.Data.Entity;
using HomeTask.DataAccess.Entities;

namespace HomeTask.DataAccess.EntitiesConfiguration
{
    public static class PopularFirstNameConfiguration
    {
        public static void ConfigurePopularFirstNameEntity(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PopularFirstNameEntity>()
                .ToTable("PopularFirstNames")
                .HasKey(x => x.PopularFirstNameId);
        } 
    }
}