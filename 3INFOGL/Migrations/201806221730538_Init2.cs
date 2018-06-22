namespace _3INFOGL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Departements", "NomDepartement", c => c.String(unicode: false));
            DropColumn("Departements", "Nom");
        }
        
        public override void Down()
        {
            AddColumn("Departements", "Nom", c => c.String(unicode: false));
            DropColumn("Departements", "NomDepartement");
        }
    }
}
