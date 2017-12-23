namespace UsersDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletecolumnSalt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 100));
            DropColumn("dbo.Users", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Salt", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 50));
        }
    }
}
