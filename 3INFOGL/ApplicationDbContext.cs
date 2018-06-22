using _3INFOGL.Configurations;
using _3INFOGL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace _3INFOGL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,
    string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("PrimaryDatabase")
        {
        }

        public DbSet<Correspondant> Correspondants { get; set; }
        public DbSet<Courrier> Courriers { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Fichier> Fichiers { get; set; }
        public DbSet<WorkFlow> WorkFlows { get; set; }


        //static ApplicationDbContext()
        //{
        //    Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        //}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartementConfiguration());
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    public class ApplicationUserStore
    : UserStore<ApplicationUser, ApplicationRole, string,
        ApplicationUserLogin, ApplicationUserRole,
        ApplicationUserClaim>, IUserStore<ApplicationUser, string>,
    IDisposable
    {
        public ApplicationUserStore()
            : this(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationUserStore(DbContext context)
            : base(context)
        {
        }
    }


    public class ApplicationRoleStore
    : RoleStore<ApplicationRole, string, ApplicationUserRole>,
    IQueryableRoleStore<ApplicationRole, string>,
    IRoleStore<ApplicationRole, string>, IDisposable
    {
        public ApplicationRoleStore()
            : base(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}