using System;
using System.ComponentModel.DataAnnotations;

namespace APIInClub.Models
{
    public class Compras
    {
        [Key]
        public int compra_codigo { get; set; }
        public int compra_usuario { get; set; }
        public int compra_producto { get; set; }
        public int compra_cantidad { get; set; }
        public decimal compra_precio { get; set; }
        public decimal compra_subtotal { get; set; }
        public decimal compra_igv { get; set; }
        public decimal compra_total { get; set; }
        public string compra_estado { get; set; }
        public DateTime compra_fecha { get; set; }

    }
}
