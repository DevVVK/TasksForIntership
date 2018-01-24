namespace UsersDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateallcolumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Login", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Gender", c => c.String(maxLength: 4));
            AlterColumn("dbo.Users", "NamePicture", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "NamePicture", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Gender", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Login", c => c.String(maxLength: 50));
        }
    }
}
