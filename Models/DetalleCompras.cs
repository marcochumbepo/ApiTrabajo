using System.ComponentModel.DataAnnotations;

namespace APIInClub.Models
{
    public class DetalleCompras
    {
        [Key]
        public int codigo_compra { get; set; }
        public string nombres_persona { get; set; }
        public string login_usuario { get; set; }
        public string nombre_producto { get; set; }
        public int cantidad_compra { get; set; }
        public decimal subtotal_compra { get; set; }
        public decimal igv_compra { get; set; }
        public decimal total_compra { get; set; }
        public string fecha_compra { get; set; }
    }
}
