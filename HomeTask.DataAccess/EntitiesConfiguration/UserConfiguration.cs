using System.Data.Entity;
using HomeTask.DataAccess.Entities;

namespace HomeTask.DataAccess.EntitiesConfiguration
{
    public static class UserConfiguration
    {
        public static void ConfigureUserEntity(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .ToTable("Users")
                .HasKey(x => x.UserId)
                .Property(x => x.HashedPassword).HasMaxLength(1024);
        }
    }
}