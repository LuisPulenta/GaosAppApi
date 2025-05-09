﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GenericApp.Web.Data.Entities
{
    public class Obra
    {
        [Key]
        public int NroObra { get; set; }
        public string NombreObra { get; set; }
        public string ELEMPEP { get; set; }
        public string OBSERVACIONES { get; set; }
        public int Finalizada { get; set; }
        public string SUPERVISORE { get; set; }
        public string CodigoEstado { get; set; }
        public string Modulo { get; set; }
        public ICollection<ObrasDocumento> ObrasDocumentos { get; set; }
        public int? CORRESPONDEABONADOS { get; set; }
        public int IdCliente { get; set; }
        public string Central { get; set; }
        public string Direccion { get; set; }
       
    }
}