using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _3INFOGL.Models
{
    public class WorkFlow
    {
        [Key]
        public string WorkFlowId { get; set; }

        public WorkFlow()
        {
            this.WorkFlowId = Guid.NewGuid().ToString();
        }

        public virtual List<Departement> Steps { get; set; }
        public virtual Document Document { get; set; }
    }
}