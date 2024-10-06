namespace HomeTask.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        FloorNumber = c.Int(nullable: false),
                        DepartmentName = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 256),
                        LastName = c.String(maxLength: 256),
                        Age = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .Index(t => t.GenderId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.EmployeeExperiences",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        ProgramingLanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.ProgramingLanguageId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.ProgramingLanguages", t => t.ProgramingLanguageId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProgramingLanguageId);
            
            CreateTable(
                "dbo.ProgramingLanguages",
                c => new
                    {
                        ProgramingLanguageId = c.Int(nullable: false, identity: true),
                        ProgramingLanguageName = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ProgramingLanguageId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        GenderName = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        HashedPassword = c.String(maxLength: 1024),
                        Username = c.String(maxLength: 256),
                        LastActionTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.EmployeeExperiences", "ProgramingLanguageId", "dbo.ProgramingLanguages");
            DropForeignKey("dbo.EmployeeExperiences", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.EmployeeExperiences", new[] { "ProgramingLanguageId" });
            DropIndex("dbo.EmployeeExperiences", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "GenderId" });
            DropTable("dbo.Users");
            DropTable("dbo.Genders");
            DropTable("dbo.ProgramingLanguages");
            DropTable("dbo.EmployeeExperiences");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
