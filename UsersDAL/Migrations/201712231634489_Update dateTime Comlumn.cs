namespace UsersDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedateTimeComlumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "DateBirth", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "DateBirth", c => c.DateTime(nullable: false));
        }
    }
}
