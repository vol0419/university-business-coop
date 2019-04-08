namespace inz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Project_ID", "dbo.Project");
            DropIndex("dbo.AspNetUsers", new[] { "Project_ID" });
            DropColumn("dbo.AspNetUsers", "Project_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Project_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Project_ID");
            AddForeignKey("dbo.AspNetUsers", "Project_ID", "dbo.Project", "ID");
        }
    }
}
