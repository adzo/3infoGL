using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _3INFOGL.Models
{
    public class Courrier
    {
        [Key]
        public string CourrierId { get; set; }
        public Boolean Sense { get; set; }
        public Boolean Etat { get; set; }
        public string TypeCourrier { get; set; }
        public string ObjetCourrier { get; set; }
        public string Detail { get; set; }

        //Foreign Key
        [ForeignKey("Correspondant")]
        public string CorrespondantId { get; set; }

        //Navigation Properties
        public virtual List<Fichier> Fichiers { get; set; }
        public virtual Correspondant Correspondant { get; set; }
    }
}