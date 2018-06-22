using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3INFOGL.Models
{
    public class Correspondant
    {
        [Key]
        public string CorrespondantId { get; set; }
        public string NomCorrespondant { get; set; }
        public Addresse Addresse { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public int Fax { get; set; }

    }
}