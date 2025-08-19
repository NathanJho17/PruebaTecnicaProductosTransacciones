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
    public class EditarProductoCase
    {
        private readonly IProductoRepository _productoService;
        private readonly IMapper _mapper;

        public EditarProductoCase(IProductoRepository productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        public async Task<RespuestaGenerica<ProductoVerDTO>> Editar(int productoId, ProductoEditarDTO dto)
        {
            try
            {
                Producto obtenerProducto = await _productoService.ObtenerProductoPorId(productoId);
                if (obtenerProducto == null)
                {
                    return new RespuestaGenerica<ProductoVerDTO>($"No se ha encontrado el producto con el id {productoId}", false, null);
                }

                Producto productoAEditar = _mapper.Map(dto, obtenerProducto);
                Producto productoEditado = await _productoService.EditarProducto(productoAEditar);

                ProductoVerDTO productoVerDTO = _mapper.Map<ProductoVerDTO>(productoEditado);

                return new RespuestaGenerica<ProductoVerDTO>("Producto editado exitosamente", true, productoVerDTO);
            }
            catch (System.Exception ex)
            {
                return new RespuestaGenerica<ProductoVerDTO>($"Se produjo un error: {ex.Message}", false, null);
            }


        }
    }
}
