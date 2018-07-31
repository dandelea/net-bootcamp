namespace NETBootcamp.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Detail = c.String(),
                        ProjectType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Detail = c.String(),
                        TaskType = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        DueTime = c.DateTime(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
        }
    }
}
