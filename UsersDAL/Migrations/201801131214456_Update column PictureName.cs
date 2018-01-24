namespace UsersDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatecolumnPictureName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PictureName", c => c.String());
            DropColumn("dbo.Users", "NamePicture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "NamePicture", c => c.String());
            DropColumn("dbo.Users", "PictureName");
        }
    }
}
