namespace inz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scientist", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scientist", "UserID");
        }
    }
}
