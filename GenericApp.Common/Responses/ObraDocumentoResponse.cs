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
        ? $"http://190.111.249.225/GaosAppApiApi/images/Obras/noimage.png"
        : $"http://190.111.249.225/GaosAppApiApi{LINK.Substring(1)}";
    }
}
