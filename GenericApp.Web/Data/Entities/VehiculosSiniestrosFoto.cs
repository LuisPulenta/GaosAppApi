using System.ComponentModel.DataAnnotations;

namespace GenericApp.Web.Data.Entities
{
    public class VehiculosSiniestrosFoto
    {
        [Key]
        public int IDFOTOSINIESTRO { get; set; }
        public int NROSINIESTROCAB { get; set; }
        public string OBSERVACION { get; set; }
        public string LINKFOTO { get; set; }
        public string CORRESPONDEA { get; set; }
        public string ImageFullPath => string.IsNullOrEmpty(LINKFOTO)
        ? $"http://keypress.serveftp.net:90/GaosAppApi/images/Siniestros/noimage.png"
        : $"http://keypress.serveftp.net:90/GaosAppApi{LINKFOTO.Substring(1)}";
    }
}