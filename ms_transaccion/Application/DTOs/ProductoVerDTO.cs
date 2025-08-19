using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProductoVerDTO
    {
        public int ProductoId { get; set; }

        public required string nombreProducto { get; set; }

        public required string descripcion { get; set; }

        public decimal precio { get; set; }

        public int stock { get; set; }
        public string imagen { get; set; } = string.Empty;
        public bool esActivo { get; set; }

        public CategoriaVerDTO CategoriaProducto { get; set; }
    }
}
