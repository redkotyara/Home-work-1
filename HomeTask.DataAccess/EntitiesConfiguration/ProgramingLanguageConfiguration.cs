using System.Data.Entity;
using HomeTask.DataAccess.Entities;

namespace HomeTask.DataAccess.EntitiesConfiguration
{
    public static class ProgramingLanguageConfiguration
    {
        public static void ConfigureProgramingLanguageEntity(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramingLanguageEntity>()
                .ToTable("ProgramingLanguages")
                .HasKey(p => p.ProgramingLanguageId);
        }
    }
}