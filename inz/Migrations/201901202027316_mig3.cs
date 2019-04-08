namespace inz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uph_offer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ImgName = c.String(),
                        Date = c.DateTime(nullable: false),
                        Author = c.String(),
                        Department = c.String(),
                        Aiddtional_information = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Category", "Uph_offer_ID", c => c.Int());
            CreateIndex("dbo.Category", "Uph_offer_ID");
            AddForeignKey("dbo.Category", "Uph_offer_ID", "dbo.Uph_offer", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "Uph_offer_ID", "dbo.Uph_offer");
            DropIndex("dbo.Category", new[] { "Uph_offer_ID" });
            DropColumn("dbo.Category", "Uph_offer_ID");
            DropTable("dbo.Uph_offer");
        }
    }
}
