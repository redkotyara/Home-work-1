using System.Data.Entity;
using HomeTask.DataAccess.Entities;
using HomeTask.DataAccess.EntitiesConfiguration;
using HomeTask.DataAccess.Migrations;

namespace HomeTask.DataAccess.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DepartmentEntity> Departments { get; set; }
        
        public DbSet<EmployeeEntity> Employees { get; set; }

        public DbSet<ProgramingLanguageEntity> ProgramingLanguages { get; set; }

        public DbSet<EmployeeExperienceEntity> EmployeeExperiences { get; set; }
        
        public DbSet<GenderEntity> Genders { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<PopularFirstNameEntity> PopularNames { get; set; }

        public DatabaseContext() : base()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder
                .Properties<string>()
                .Configure(p => p.HasMaxLength(256));
            
            modelBuilder.ConfigureDepartmentEntity();
            modelBuilder.ConfigureProgramingLanguageEntity();
            modelBuilder.ConfigureEmployeeEntity();
            modelBuilder.ConfigureEmployeeExperienceConfiguration();
            modelBuilder.ConfigureGenderEntity();
            modelBuilder.ConfigureUserEntity();
            modelBuilder.ConfigurePopularFirstNameEntity();
        }
    }
}