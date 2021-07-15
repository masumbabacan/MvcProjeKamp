namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_aaaa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary(maxLength: 500));
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary(maxLength: 500));
            DropColumn("dbo.Admins", "AdminPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminPasswordHash");
            DropColumn("dbo.Admins", "AdminPasswordSalt");
        }
    }
}
