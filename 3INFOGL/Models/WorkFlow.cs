using System.Collections.Generic;

namespace _3INFOGL.Models
{
    public class WorkFlow
    {
        public string WorkFlowId { get; set; }


        public virtual List<Departement> Steps { get; set; }
    }
}