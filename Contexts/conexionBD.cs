using APIInClub.Models;
using Microsoft.EntityFrameworkCore;

namespace APIInClub.Contexts
{
    public class conexionBD: DbContext
    {
        public conexionBD(DbContextOptions<conexionBD> options) : base(options)
        {
            //
        }
        public DbSet<Products> Productos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<DetalleCompras> Detalles { get; set; }
    }
}
