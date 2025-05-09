﻿using System.ComponentModel.DataAnnotations;

namespace GenericApp.Web.Data.Entities
{
    public class Usuario
    {
        [Key]
        public int IDUsuario { get; set; }
        public string Login { get; set; }
        public string CodigoCausante { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public byte Estado { get; set; }
        public int? HabilitaAPP { get; set; }
        public int? HabilitaFotos { get; set; }
        public int? HabilitaReclamos { get; set; }
        public int? HabilitaSSHH { get; set; }
        public int? HabilitaMedidores { get; set; }
        public int? HabilitaFlotas { get; set; }
        public string Modulo { get; set; }
        public string CODIGOGRUPO { get; set; }
        public int? FechaCaduca { get; set; }
        public int? IntentosInvDiario { get; set; }
        public int? OpeAutorizo { get; set; }
        public int IdEmpresa { get; set; }
        public string FullName => $"{Nombre} {Apellido}";
    }
}
