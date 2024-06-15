using Microsoft.EntityFrameworkCore;
using Tiendas.Entities;

namespace Tiendas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Sucursal> Sucursales{ get; set; }

        public DbSet<Categoria> Categorias{ get; set; }
    }
}