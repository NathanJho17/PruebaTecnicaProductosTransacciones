using Application.DTOs;
using AutoMapper;
using Domain;

namespace Application;

public class CrearProductoUseCase
{
    private readonly IProductoRepository _productoService;
    private readonly IMapper _mapper;

    public CrearProductoUseCase(IProductoRepository productoService, IMapper mapper)
    {
        _productoService = productoService;
        _mapper = mapper;
    }

    public async Task<RespuestaGenerica<ProductoVerDTO>> Crear(ProductoCrearDTO productoCrearDTO)
    {
        try
        {
            var mapProducto = _mapper.Map<Producto>(productoCrearDTO);
            var productoCreado = await _productoService.CrearProducto(mapProducto);
            var mapVerProducto = _mapper.Map<ProductoVerDTO>(productoCreado);
            return new RespuestaGenerica<ProductoVerDTO>("Producto creado exitosamente", true, mapVerProducto);
        }
        catch (System.Exception ex)
        {
            return new RespuestaGenerica<ProductoVerDTO>($"Se produjo un error: {ex.Message}", false, null);
        }

    }
}
