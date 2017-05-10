namespace Integre.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collaborator",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name_FirstName = c.String(nullable: false, maxLength: 60),
                        Name_LastName = c.String(nullable: false, maxLength: 60),
                        Email_Address = c.String(nullable: false, maxLength: 160),
                        Document_Number = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 32, fixedLength: true),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Collaborator", "User_Id", "dbo.User");
            DropIndex("dbo.Collaborator", new[] { "User_Id" });
            DropTable("dbo.User");
            DropTable("dbo.Collaborator");
        }
    }
}
