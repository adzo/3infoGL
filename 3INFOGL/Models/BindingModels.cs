using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3INFOGL.Models
{
    public class BindingModels
    {
    }

    public class DocumentFichierBindingModel
    {
        public Document Document { get; set; }
        public Fichier Fichier { get; set; }
    }
}