using System;
using System.ComponentModel.DataAnnotations;

namespace APIInClub.Models
{
    public class Products
    {
        [Key]
        public int producto_id {get;set;}
        public string producto_nombre { get; set; }
        public decimal producto_precio { get; set; }
        public string producto_estado { get; set; }
        public string producto_UsuCreacion { get; set; }
        public DateTime producto_FecCreacion { get; set; }
        public string producto_UsuModificacion { get; set; }
        public DateTime producto_FecModificacion { get; set; }

    }
}
