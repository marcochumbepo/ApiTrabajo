using System;
using System.ComponentModel.DataAnnotations;

namespace APIInClub.Models
{
    public class Usuarios
    {
        [Key]
        public int usuario_codigo {get; set;}
        public string usuario_nombres { get; set; }
        public string usuario_apellidos { get; set; }
        public string usuario_login { get; set; }
        public string usuario_clave { get; set; }
        public string usuario_estado { get; set; }
        public DateTime usuario_FecRegistro { get; set; }
        public string usuario_UsuRegistro { get; set; }

    }
}
