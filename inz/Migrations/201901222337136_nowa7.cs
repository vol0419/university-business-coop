namespace inz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agent", "UserID", c => c.String());
            AddColumn("dbo.Project", "Mails", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "Mails");
            DropColumn("dbo.Agent", "UserID");
        }
    }
}
