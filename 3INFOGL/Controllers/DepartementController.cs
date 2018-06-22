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
        [Route("GetDepartements")]
        public List<Departement> GetDepartements()
        {
            List<Departement> resultat = AdbContext.Departements.ToList();
            


            return resultat;
        }


        //get api/Departement/getDepartementById
        [ResponseType(typeof(Departement))]
        [AllowAnonymous]
        [Route("GetDepartementById/{id}")]
        public Departement GetDepartementById(int id)
        {
            Departement resultat = AdbContext.Departements.Find(id);
            return resultat;
        }

        // POST api/Departement/AddDepartement
        [AllowAnonymous]
        [Route("AddDepartement")]
        public IHttpActionResult AddDepartment(Departement model)
        {
            AdbContext.Departements.Add(model);
            AdbContext.SaveChanges();
            return Ok("model: "+model.NomDepartement+", "+model.Responsable);
        }

        //[AllowAnonymous]
        //[Route("AddDepartement")]
        //public IHttpActionResult AddDepartment()
        //{
        //    return Ok("got to the action");
        //}
    }
}
