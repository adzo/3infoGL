using _3INFOGL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _3INFOGL.Controllers
{
    [RoutePrefix("api/WorkFlow")]
    public class WorkFlowController : ApiController
    {
        ApplicationDbContext AdbContext = new ApplicationDbContext();

        [Route("Add")]
        public IHttpActionResult Add(WorkFlow Work)
        {
            AdbContext.WorkFlows.Add(Work);
            AdbContext.SaveChanges();
            return Ok();
        }

        [Route("Get/{id}")]
        public WorkFlow Get(int id)
        {
            return AdbContext.WorkFlows.Find(id);
        }

    }
}
