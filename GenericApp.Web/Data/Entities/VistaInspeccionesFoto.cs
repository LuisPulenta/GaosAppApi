using System;
using System.ComponentModel.DataAnnotations;

namespace GenericApp.Web.Data.Entities
{
    public class VistaInspeccionesFoto
    {
        [Key]
        public int IDRegistro { get; set; }
        public string LinkFoto { get; set; }
        public int UsuarioAlta { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string CausanteC { get; set; }
        public string GrupoC { get; set; }
        public string Causante { get; set; }
        public string Descripcion { get; set; }
        public string Cumple { get; set; }
        public string Cliente { get; set; }
        public string ImageFullPath => string.IsNullOrEmpty(LinkFoto)
        ? $"http://keypress.serveftp.net:90/GaosAppApi/images/Inspecciones/noimage.png"
        : $"http://keypress.serveftp.net:90/GaosAppApi{LinkFoto.Substring(1)}";

    }
}