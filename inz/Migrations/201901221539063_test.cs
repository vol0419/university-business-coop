namespace inz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "test", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "test");
        }
    }
}
