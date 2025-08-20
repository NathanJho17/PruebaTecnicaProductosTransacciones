using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UsesCases
{
    public class EliminarTransaccionSoftUseCase
    {
        private readonly ITransaccionRepository _transaccionRepository;
        private readonly IProductoExternoService _productoExternoService;
        private readonly StockService _stockService;

        public EliminarTransaccionSoftUseCase(ITransaccionRepository transaccionRepository,
            IProductoExternoService productoExternoService,
            StockService stockService)
        {
            _transaccionRepository = transaccionRepository;
            _productoExternoService = productoExternoService;
            _stockService = stockService;
        }

        public async Task<RespuestaGenerica<bool>> EliminarTransaccion(Guid guidTransaccion)
        {
            try
            {
                Transaccion obtenerTransaccion = await _transaccionRepository.ObtenerTransaccionPorId(guidTransaccion);
                if (obtenerTransaccion == null)
                {
                    return new RespuestaGenerica<bool>($"No se ha encontrado la transacción con el id {guidTransaccion.ToString()}", false, false);
                }

                ProductoVerDTO producto = await _productoExternoService.ObtenerProductoId(obtenerTransaccion.ProductoId);
                //Actualizar stock producto
                var actualizarStockProducto = await _productoExternoService.EditarProducto(obtenerTransaccion.ProductoId, new ProductoEditarDTO
                {
                    //devolver el stock con la cantidad del registro a inactivar/eliminar lógicamente
                    Stock = _stockService.ProcesarStock(producto.stock, obtenerTransaccion.Cantidad, "venta"),
                    Descripcion = producto.descripcion,
                    NombreProducto = producto.nombreProducto,
                    EsActivo = producto.esActivo,
                    Imagen = producto.imagen,
                    Precio = producto.precio,
                    IdCategoria = producto.CategoriaProducto.CategoriaId
                });

                bool transaccionEliminada = await _transaccionRepository.BorrarTransaccionSoft(obtenerTransaccion);

                return new RespuestaGenerica<bool>("Transacción elimnada exitosamente", true, transaccionEliminada);
            }
            catch (Exception ex)
            {

                return new RespuestaGenerica<bool>($"Se produjo un error: {ex.Message}", false, false);

            }
            

        }
    }
}
