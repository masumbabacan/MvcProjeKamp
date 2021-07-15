namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Aaaaaaaaaaa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminPassword", c => c.Binary(maxLength: 500));
            DropColumn("dbo.Admins", "AdminPasswordSalt");
            DropColumn("dbo.Admins", "AdminPasswordHash");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary(maxLength: 500));
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary(maxLength: 500));
            DropColumn("dbo.Admins", "AdminPassword");
        }
    }
}
