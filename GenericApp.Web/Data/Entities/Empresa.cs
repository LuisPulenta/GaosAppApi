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
        public string ConexionServidor { get; set; }
        public string NombreBDObra { get; set; }
        public string UsuarioBDObra { get; set; }
        public string PasswordBDObra { get; set; }
        public string NombreBDInv { get; set; }
        public string UsuarioBDInv { get; set; }
        public string PasswordBDInv { get; set; }
        public string LogoFullPath => string.IsNullOrEmpty(LogoEmpresa)
       ? $"http://keypress.serveftp.net:90/GaosAppApi/images/noimage.png"
       : $"http://keypress.serveftp.net:90/GaosAppApi{LogoEmpresa.Substring(1)}";
    }
}
