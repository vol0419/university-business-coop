namespace inz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        OfferFrom = c.String(),
                        Agent = c.String(),
                        Taken = c.Boolean(nullable: false),
                        Description = c.String(),
                        Uph_offerID = c.Int(nullable: false),
                        AgentID = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Order");
        }
    }
}
