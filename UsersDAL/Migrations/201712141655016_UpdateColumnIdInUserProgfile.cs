namespace UsersDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnIdInUserProgfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "Id", "dbo.UserProfiles");
            DropIndex("dbo.UserProfiles", new[] { "Id" });
            DropPrimaryKey("dbo.UserProfiles");
            AlterColumn("dbo.UserProfiles", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserProfiles", "Id");
            CreateIndex("dbo.UserProfiles", "Id");
            AddForeignKey("dbo.Pictures", "Id", "dbo.UserProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "Id", "dbo.UserProfiles");
            DropIndex("dbo.UserProfiles", new[] { "Id" });
            DropPrimaryKey("dbo.UserProfiles");
            AlterColumn("dbo.UserProfiles", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserProfiles", "Id");
            CreateIndex("dbo.UserProfiles", "Id");
            AddForeignKey("dbo.Pictures", "Id", "dbo.UserProfiles", "Id");
        }
    }
}
