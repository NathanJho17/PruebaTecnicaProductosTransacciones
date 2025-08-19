using System.ComponentModel.DataAnnotations;

namespace Application;

public class ProductoCrearDTO
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
    public string Imagen { get; set; }=string.Empty;
}
