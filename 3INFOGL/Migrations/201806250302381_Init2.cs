namespace _3INFOGL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Fichiers", "DocumentId", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("Fichiers", "DocumentId");
        }
    }
}
