using _3INFOGL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _3INFOGL.Controllers
{
    [Authorize]
    [RoutePrefix("api/Fichier")]
    public class FichierController : ApiController
    {
        ApplicationDbContext AdbContext = new ApplicationDbContext();
        public IHttpActionResult Create (Fichier fichier)
        {
            AdbContext.Fichiers.Add(fichier);
            return Ok();
        }

        [Route("Get/{id}")]
        public Fichier Get(int id)
        {
            return AdbContext.Fichiers.Find(id);
        }

        [Route("Get")]
        public List<Fichier> Get()
        {
            return AdbContext.Fichiers.ToList();
        }

        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            Fichier file = AdbContext.Fichiers.Find(id);
            AdbContext.Fichiers.Remove(file);
            AdbContext.SaveChanges();
            return Ok();
        }
    }
}
