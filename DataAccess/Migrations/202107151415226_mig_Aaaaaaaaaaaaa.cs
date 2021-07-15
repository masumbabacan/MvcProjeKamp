namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Aaaaaaaaaaaaa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminFirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminLastName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminLastName");
            DropColumn("dbo.Admins", "AdminFirstName");
        }
    }
}
