namespace NETBootcamp.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Projects", "Detail", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Tasks", "Title", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Tasks", "Detail", c => c.String(maxLength: 1000));
            CreateIndex("dbo.Tasks", "ProjectID");
            AddForeignKey("dbo.Tasks", "ProjectID", "dbo.Projects", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ProjectID", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "ProjectID" });
            AlterColumn("dbo.Tasks", "Detail", c => c.String());
            AlterColumn("dbo.Tasks", "Title", c => c.String());
            AlterColumn("dbo.Projects", "Detail", c => c.String());
            AlterColumn("dbo.Projects", "Title", c => c.String());
        }
    }
}
