namespace _3INFOGL.Migrations
{

    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Utilities;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
            CodeGenerator = new MySql.Data.Entity.MySqlMigrationCodeGenerator();
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }



    //class MyCodeGenerator : System.Data.Entity.Migrations.Design.CSharpMigrationCodeGenerator
    //{
    //    protected override void Generate(
    //        System.Data.Entity.Migrations.Model.DropIndexOperation dropIndexOperation, IndentedTextWriter writer)
    //    {
    //        dropIndexOperation.Table = StripDbo(dropIndexOperation.Table);

    //        base.Generate(dropIndexOperation, writer);
    //    }

    //    // TODO: Override other Generate overloads that involve table names

    //    private string StripDbo(string table)
    //    {
    //        if (table.StartsWith("dbo."))
    //        {
    //            return table.Substring(4);
    //        }

    //        return table;
    //    }
    //}


}
