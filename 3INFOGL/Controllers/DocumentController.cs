using _3INFOGL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _3INFOGL.Controllers
{
    [RoutePrefix("api/Document")]
    public class DocumentController : ApiController
    {
        ApplicationDbContext AdbContext = new ApplicationDbContext();

        // POST api/Document/Create
        [Route("Create")]
        public IHttpActionResult Create(DocumentFichierBindingModel model)
        {
            Fichier file = new Fichier()
            {
                NomFichier = model.Fichier.NomFichier,
                UrlFichier = model.Fichier.UrlFichier
            };
            AdbContext.Fichiers.Add(file);
            Document doc = new Document()
            {
                DocumentId = file.FichierId,
                DateCreation = DateTime.Now.ToString("dd-MM-yyyy"),
                ApplicationUserId = model.Document.ApplicationUserId,
                CreationUser = model.Document.CreationUser,
                CurrentStat = 0,
                Etat = false,
                NomDocument = model.Document.NomDocument,
                Fichier = file
            };
            AdbContext.Documents.Add(doc);
            AdbContext.SaveChanges();
            return Ok();
        }

        // POST api/Document/Validate/{id}
        [Route("Validate/{id}")]
        public IHttpActionResult Validate(string id)
        {
            AdbContext.Documents.Find(id).Etat = true;
            AdbContext.SaveChanges();
            return Ok();
        }

        // Get api/Document/Get
        [Route("Get")]
        public List<Document> Get()
        {
            return AdbContext.Documents.ToList();
        }

        // Get api/Document/GetByUser (user in request body)
        [Route("GetByUser")]
        public List<Document> GetByUser (ApplicationUser user)
        {
            List<Document> result = new List<Document>();
            foreach(Document doc in AdbContext.Documents.ToList())
            {
                if(doc.WorkFlow.Steps.ElementAt(doc.CurrentStat) == user.Departement)
                {
                    result.Add(doc);
                }
            }
            return result;
        }


        // Get api/Document/Get/{id}
        [Route("Get/{id}")]
        public Document Get(string id)
        {
            return AdbContext.Documents.Find(id);
        }
    }
}
