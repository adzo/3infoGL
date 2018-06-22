using _3INFOGL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace _3INFOGL.Configurations
{
    public class DepartementConfiguration : EntityTypeConfiguration<Departement>
    {
        public DepartementConfiguration()
        {
            HasMany<ApplicationUser>(d => d.Users).
                WithRequired(u => u.Departement).
                HasForeignKey(u => u.DepartementId);
        }
    }
}