using Application.DTOs;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UsesCases
{
    public class ListarProductosUseCase
    {
        private readonly IProductoRepository _productoService;
        private readonly IMapper _mapper;

        public ListarProductosUseCase(IProductoRepository productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        public async Task<RespuestaGenerica<List<ProductoVerDTO>>> Listar(int desde, int limite)
        {
            try
            {
                List<Producto> productos = await _productoService.ListarProductos(desde, limite);
                List<ProductoVerDTO> productoVerDTOs = _mapper.Map<List<ProductoVerDTO>>(productos);
                return new RespuestaGenerica<List<ProductoVerDTO>>($"Total productos obtenidos {productoVerDTOs.Count}", true, productoVerDTOs);
            }
            catch (System.Exception ex)
            {
                return new RespuestaGenerica<List<ProductoVerDTO>>($"Se produjo un error: {ex.Message}", false, null);
            }

        }
    }
}
