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
    public class ObtenerProductoIdCase
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ObtenerProductoIdCase(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<RespuestaGenerica<ProductoVerDTO>> ObtenerProducto(int productoId)
        {
            try
            {
                Producto producto = await _productoRepository.ObtenerProductoPorId(productoId);
                if (producto == null)
                {
                    return new RespuestaGenerica<ProductoVerDTO>("Producto no encontrado", false, null);
                }

                ProductoVerDTO productoVerDTO = _mapper.Map<ProductoVerDTO>(producto);
                return new RespuestaGenerica<ProductoVerDTO>($"Producto {producto.Nombre} encontrado", true, productoVerDTO);
            }
            catch (System.Exception ex)
            {
                return new RespuestaGenerica<ProductoVerDTO>($"Se produjo un error: {ex.Message}", false, null);
            }
        }
    }
}
