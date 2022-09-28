using System;

namespace GenericApp.Common.Responses
{
    public class ObraDocumentoResponse
    {
        public int NROREGISTRO { get; set; }
        public int NROOBRA { get; set; }
        public string OBSERVACION { get; set; }
        public string LINK { get; set; }
        public DateTime? FECHA { get; set; }
        public string ImageFullPath => string.IsNullOrEmpty(LINK)
        ? $"http://keypress.serveftp.net:90/GaosAppApi/images/Obras/noimage.png"
        : $"http://keypress.serveftp.net:90/GaosAppApi{LINK.Substring(1)}";
    }
}
