namespace UsersDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnNamePicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "NamePicture", c => c.String(nullable: false));
            DropColumn("dbo.Pictures", "NamePacture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "NamePacture", c => c.String(nullable: false));
            DropColumn("dbo.Pictures", "NamePicture");
        }
    }
}
