namespace HomeTask.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPopularNamesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PopularFirstNames",
                c => new
                    {
                        PopularFirstNameId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.PopularFirstNameId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PopularFirstNames");
        }
    }
}
