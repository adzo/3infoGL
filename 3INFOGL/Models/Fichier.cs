using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3INFOGL.Models
{
    public class Fichier
    {
        public string FichierId { get; set; }
        public string NomFichier { get; set; }
        public string UrlFichier { get; set; }

        //Ce field est nullable (string)
        //un fichier peut appartenir a un document ou un courrier
        public string CourrierId { get; set; }

    }
}