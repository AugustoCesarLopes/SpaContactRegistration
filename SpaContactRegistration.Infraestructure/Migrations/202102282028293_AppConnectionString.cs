namespace SpaContactRegistration.Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppConnectionString : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Email = c.String(nullable: false, maxLength: 160),
                        Telefone = c.String(maxLength: 12, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "IX_EMAIL");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contact", "IX_EMAIL");
            DropTable("dbo.Contact");
        }
    }
}
