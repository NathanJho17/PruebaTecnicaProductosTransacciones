using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProductoVerDTO:ProductoCrearDTO
    {
        public int ProductoId { get; set; }
        public bool EsActivo { get; set; }

        public CategoriaVerDTO CategoriaProducto { get; set; }
    }
}
