using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3INFOGL.Models
{
    public class Departement
    {
        public string DepartementId { get; set; }
        public string NomDepartement { get; set; }
        public string Responsable { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }


        public virtual List<ApplicationUser> Users { get; set; }
        public virtual List<WorkFlow> WorkFlows { get; set; }

        public Departement()
        {
            this.DepartementId = Guid.NewGuid().ToString();
        }
    }
}