using System;

namespace GenericApp.Common.Responses
{
    public class CausanteResponse
    {
        public int NroCausante { get; set; }
        public string grupo { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public bool estado { get; set; }
        public string direccion { get; set; }
        public int? Numero { get; set; }
        public string Piso { get; set; }
        public string Dpto { get; set; }
        public string Torre { get; set; }
        public string Ciudad { get; set; }
        public string telefono { get; set; }
        public string CaracTelefono { get; set; }
        public string CODPOS { get; set; }
        public string ENCARGADO { get; set; }
        public string EMAIL { get; set; }
        public DateTime? fecha { get; set; }
        public byte? TIPOPROV { get; set; }
        public string CUIT { get; set; }
        public string RazonSocial { get; set; }
        public int? NIVEL { get; set; }
        public string BARRIO { get; set; }
        public string FAX { get; set; }
        public string CaracFax { get; set; }
        public string Provincia { get; set; }
        public string NotasCausantes { get; set; }
        public string NOTAS { get; set; }
        public int IdEmpresa { get; set; }
        public string DNI { get; set; }
    }
}