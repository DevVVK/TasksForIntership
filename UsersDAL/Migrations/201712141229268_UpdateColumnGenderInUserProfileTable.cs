namespace UsersDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnGenderInUserProfileTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "Gender", c => c.String(nullable: false, maxLength: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "Gender", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
