using System.ComponentModel.DataAnnotations;

namespace GenericApp.Web.Data.Entities
{
    public class Usuario2
    {
        [Key]
        public int IDUsuario { get; set; }
        public string Login { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
