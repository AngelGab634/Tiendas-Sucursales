namespace Tiendas.Entities
{
    public class Categoria
    {
        public Categoria()
        {
        }

        public Guid Id { get; set; }

        public string Name { get; set;}

        public string descripcion { get; set;}

        public List<Categoria> Categorias{ get; set; }

    }
}