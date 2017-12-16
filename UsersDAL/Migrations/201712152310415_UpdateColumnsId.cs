namespace UsersDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnsId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Pictures", new[] { "Id" });
            DropPrimaryKey("dbo.Pictures");
            AlterColumn("dbo.Pictures", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Pictures", "Id");
            CreateIndex("dbo.Pictures", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pictures", new[] { "Id" });
            DropPrimaryKey("dbo.Pictures");
            AlterColumn("dbo.Pictures", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Pictures", "Id");
            CreateIndex("dbo.Pictures", "Id");
        }
    }
}
