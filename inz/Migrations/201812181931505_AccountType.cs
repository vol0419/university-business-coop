namespace inz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AccountType", c => c.String());
            AlterColumn("dbo.Firm", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Firm", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "AccountType");
        }
    }
}
