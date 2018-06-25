using _3INFOGL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace _3INFOGL.Controllers
{
    [RoutePrefix("api/Departement")]
    public class DepartementController : ApiController
    {


        ApplicationDbContext AdbContext = new ApplicationDbContext();

        public DepartementController()
        {

        }

        //get api/Departement/GetDepartement
        [ResponseType(typeof(List<Departement>))]
        [AllowAnonymous]
        [Route("Get")]
        public List<Departement> Get()
        {
            List<Departement> resultat = AdbContext.Departements.ToList();
            


            return resultat;
        }


        //get api/Departement/getDepartementById
        [ResponseType(typeof(Departement))]
        [AllowAnonymous]
        [Route("Get/{id}")]
        public Departement Get(int id)
        {
            Departement resultat = AdbContext.Departements.Find(id);
            return resultat;
        }

        // POST api/Departement/AddDepartement
        [AllowAnonymous]
        [Route("Create")]
        public IHttpActionResult Create(Departement model)
        {
            AdbContext.Departements.Add(model);
            AdbContext.SaveChanges();
            return Ok("model: "+model.NomDepartement+", "+model.Responsable);
        }

        [Route("Update")]
        public IHttpActionResult Update(Departement model)
        {
            Departement dep = AdbContext.Departements.Find(model.DepartementId);
            dep.Email = model.Email;
            dep.NomDepartement = model.NomDepartement;
            dep.Responsable = model.Responsable;
            dep.Telephone = model.Telephone;
            AdbContext.SaveChanges();
            return Ok("Update with success");
        }



    }
}
