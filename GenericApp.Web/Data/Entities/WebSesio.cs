﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GenericApp.Web.Data.Entities
{
    public class WebSesio
    {
        [Key]
        
        public int NROCONEXION { get; set; }
        public string USUARIO { get; set; }
        public string IP { get; set; }
        public DateTime LOGINDATE { get; set; }
        public int? LOGINTIME { get; set; }
        public string MODULO { get; set; }
        public DateTime? LOGOUTDATE { get; set; }
        public int? LOGOUTTIME { get; set; }
        public int? CONECTAVERAGE { get; set; }
        public string VersionSistema { get; set; }

        public int ID_WS { get; set; }
    }
}
