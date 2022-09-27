using System.ComponentModel.DataAnnotations;

namespace GenericApp.Web.Data.Entities
{
    public class Empresa
    {
        [Key]
        public int IDEmpresa { get; set; }
        public string NOMBREEMPRESA { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string CarpetaImagenes { get; set; }
        public string MensageSSHH { get; set; }
    }
}
