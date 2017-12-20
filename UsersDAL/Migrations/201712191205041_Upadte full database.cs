namespace UsersDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upadtefulldatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfiles", "Id", "dbo.Users");
            DropForeignKey("dbo.Pictures", "Id", "dbo.UserProfiles");
            DropIndex("dbo.Pictures", new[] { "Id" });
            DropIndex("dbo.UserProfiles", new[] { "Id" });
            AddColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "Gender", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.Users", "DateBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "NamePicture", c => c.String(nullable: false));
            DropTable("dbo.Pictures");
            DropTable("dbo.UserProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 4),
                        DateBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NamePicture = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Users", "NamePicture");
            DropColumn("dbo.Users", "DateBirth");
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            CreateIndex("dbo.UserProfiles", "Id");
            CreateIndex("dbo.Pictures", "Id");
            AddForeignKey("dbo.Pictures", "Id", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.UserProfiles", "Id", "dbo.Users", "Id");
        }
    }
}
