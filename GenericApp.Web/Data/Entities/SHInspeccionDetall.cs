using System;
using System.ComponentModel.DataAnnotations;

namespace GenericApp.Web.Data.Entities
{
    public class SHInspeccionDetall
    {
        [Key]
        public int IDRegistro { get; set; }
        public int InspeccionCab { get; set; }
        public int IdCliente { get; set; }
        public int IDGrupoFormulario { get; set; }
        public string DetalleF { get; set; }
        public string Descripcion { get; set; }
        public int PonderacionPuntos { get; set; }
        public string Cumple { get; set; }
        public string LinkFoto { get; set; }

        public string ImageFullPath => string.IsNullOrEmpty(LinkFoto)
        ? $"http://keypress.serveftp.net:90/GaosAppApi/images/noimage.png"
        : $"http://keypress.serveftp.net:90/GaosAppApi{LinkFoto.Substring(1)}";


    }
}