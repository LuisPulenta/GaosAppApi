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
        public bool Activo { get; set; }
        public string LogoEmpresa { get; set; }
        public string LogoFullPath => string.IsNullOrEmpty(LogoEmpresa)
       ? $"http://190.111.249.225/GaosAppApiApi/images/Obras/noimage.png"
       : $"http://190.111.249.225/GaosAppApiApi{LogoEmpresa.Substring(1)}";
    }
}
