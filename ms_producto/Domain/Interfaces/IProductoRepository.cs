namespace Domain;

public interface IProductoRepository
{
    Task<Producto?> CrearProducto(Producto producto);

    Task<List<Producto>> ListarProductos(int desde,int limite);

    Task<Producto> EditarProducto(Producto producto);


    Task<Producto?> ObtenerProductoPorId(int productoId);
    Task<bool> BorrarProductoSoft(Producto producto);


}
