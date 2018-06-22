namespace _3INFOGL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateIdentityModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("ApplicationUsers", "Telephone");
        }
        
        public override void Down()
        {
            AddColumn("ApplicationUsers", "Telephone", c => c.Int(nullable: false));
        }
    }
}
