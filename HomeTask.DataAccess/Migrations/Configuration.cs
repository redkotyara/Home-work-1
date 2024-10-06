using HomeTask.DataAccess.Entities;

namespace HomeTask.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeTask.DataAccess.DatabaseContexts.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HomeTask.DataAccess.DatabaseContexts.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            
            var firstProgramLanguage = new ProgramingLanguageEntity
            {
                ProgramingLanguageName = "Javascript",
                ProgramingLanguageId = 1
            };
            
            var secondProgramLanguage = new ProgramingLanguageEntity
            {
                ProgramingLanguageName = "Rust",
                ProgramingLanguageId = 2
            };
            
            var thirdProgramLanguage = new ProgramingLanguageEntity
            {
                ProgramingLanguageName = "Python",
                ProgramingLanguageId = 3
            };
            
            var firstDepartment = new DepartmentEntity
            {
                DepartmentName = "Technical support",
                FloorNumber = 2,
                DepartmentId = 1
            };
            
            var secondDepartment = new DepartmentEntity
            {
                DepartmentName = "Security",
                FloorNumber = 3,
                DepartmentId = 2
            };
            
            var thirdDepartment = new DepartmentEntity
            {
                DepartmentName = "Development",
                FloorNumber = 1,
                DepartmentId = 3
            };
            
            var firstGender = new GenderEntity
            {
                GenderName = "Male",
                GenderId = 1
            };

            var secondGender = new GenderEntity
            {
                GenderName = "Female",
                GenderId = 2
            };
            
            context.ProgramingLanguages.AddOrUpdate(firstProgramLanguage, secondProgramLanguage, thirdProgramLanguage);
            context.Departments.AddOrUpdate(firstDepartment, secondDepartment, thirdDepartment);
            context.Genders.AddOrUpdate(firstGender, secondGender);

            var firstPopularName = new PopularFirstNameEntity
            {
                Name = "Jack",
                PopularFirstNameId = 1
            };
            
            var secondPopularName = new PopularFirstNameEntity
            {
                Name = "Bob",
                PopularFirstNameId = 2
            };
            
            context.PopularNames.AddOrUpdate(firstPopularName, secondPopularName);
            
            context.SaveChanges();
        }
    }
}
