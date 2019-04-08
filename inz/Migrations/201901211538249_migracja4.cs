namespace inz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracja4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Polling",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FormLink = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Scientist",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        Department = c.String(),
                        Mail = c.String(),
                        Phone = c.Int(nullable: false),
                        City = c.String(),
                        ImgName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Scientist");
            DropTable("dbo.Polling");
        }
    }
}
