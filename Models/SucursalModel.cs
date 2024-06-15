using Tiendas.Entities;

namespace Tiendas.Models
{
    public class SucursalModel
    {
        public SucursalModel ()
        {

        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string direccion {get; set; }

        public string gerenteSuc { get; set; }

        public int telefono { get; set; }

        public Guid? CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }

    }
}