using Domain.Models;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Producto: PropiedadesGenerica
{

   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get;  set; }
    public string Nombre { get;  set; } = null!;
    public string Descripcion { get;  set; } = null!;
    public decimal Precio { get;  set; }
    public int Stock { get;  set; }
    public int CategoriaId { get;  set; }
    public string Imagen { get;  set; } = null!;

    public Categoria Categoria { get;  set; } = null!;

    public Producto()
    {
        
    }
    public Producto(string nombre, string descripcion, decimal precio, int stock, int categoriaId, string imagen)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
        Stock = stock;
        CategoriaId = categoriaId;
        Imagen = imagen;
    }

    public Producto(string nombre, string descripcion, decimal precio, int stock, int categoriaId, string imagen, bool esActivo)
        : this(nombre,  descripcion,  precio,  stock,  categoriaId,  imagen)
    {
      
        Activo = esActivo;
    }
}
