using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProductoEditarDTO
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        public required string NombreProducto { get; set; }

        public required string Descripcion { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        public decimal Precio { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        [Required(ErrorMessage = "El stock del producto es obligatorio.")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "La categoría del producto es obligatoria.")]
        public int IdCategoria { get; set; }
        public string Imagen { get; set; } = string.Empty;

        public bool EsActivo { get; set; }

    }
}
