using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ProductoRepository : IProductoRepository
{
    private readonly ApplicationDbContext _context;

    public ProductoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> BorrarProductoSoft(Producto producto)
    {
        try
        {
            producto.Activo = false;
            _context.Producto.Update(producto);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            throw new Exception("Error al eliminar el producto");
        }
    }

    public async Task<Producto?> CrearProducto(Producto producto)
    {
        try
        {
            _context.Add(producto);
            _context.SaveChanges();

            Producto? productoConCategoria = await _context.Producto
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.Id == producto.Id);

            return productoConCategoria;
        }
        catch (System.Exception)
        {

            throw new Exception("Error al crear el producto");
        }

    }

    public async Task<Producto> EditarProducto(Producto producto)
    {
        try
        {
             _context.Producto.Update(producto);
            await _context.SaveChangesAsync();
            return producto;
        }
        catch (Exception)
        {

            throw new Exception("Error al editar el producto");
        }
    }

    public async Task<List<Producto>> ListarProductos(int desde, int limite)
    {
        try
        {

            var productos = await _context.Producto.
                Where(p => p.Activo == true)
               .Skip(((desde == 0) ? 1 : desde - 1) * limite)
                .Take(limite)
                .Include(c => c.Categoria) // Aplicando Eagger loading
                .ToListAsync();

            return productos;
        }
        catch (System.Exception)
        {

            throw new Exception("Error al obtener listado de productos");
        }
    }

    public async Task<Producto?> ObtenerProductoPorId(int productoId)
    {
        try
        {
            Producto? encontrado = await _context.Producto.Where(p => p.Id == productoId)
                .Include(c => c.Categoria).FirstOrDefaultAsync();

            return encontrado;
        }
        catch (Exception)
        {

            throw new Exception("Error al obtener el producto");
        }
    }
}
