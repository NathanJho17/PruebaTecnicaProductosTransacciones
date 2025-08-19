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
    public class EliminarProductoSoftUseCase
    {
        private readonly IProductoRepository _productoService;

        public EliminarProductoSoftUseCase(IProductoRepository productoService)
        {
            _productoService = productoService;
        }

        public async Task<RespuestaGenerica<bool>> EliminarSoft(int productoId)
        {
            try
            {
                Producto obtenerProducto = await _productoService.ObtenerProductoPorId(productoId);
                if (obtenerProducto == null)
                {
                    return new RespuestaGenerica<bool>($"No se ha encontrado el producto con el id {productoId}", false, false);
                }

                bool productoEliminado = await _productoService.BorrarProductoSoft(obtenerProducto);
                return new RespuestaGenerica<bool>("Producto eliminado exitosamente", true, productoEliminado);
            }
            catch (System.Exception ex)
            {

                return new RespuestaGenerica<bool>($"Se produjo un error: {ex.Message}", false, false);

            }


        }
    }
}
