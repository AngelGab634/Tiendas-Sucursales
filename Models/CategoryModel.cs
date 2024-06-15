using System.ComponentModel.DataAnnotations;
using Tiendas.Entities;

namespace Tiendas.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string descripcion { get; set; }

    }
}