using Application.DTOs;
using AutoMapper;
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
    public class EditarTransaccionUseCase
    {
        private readonly ITransaccionRepository _transaccionRepository;
        private readonly IMapper _mapper;
        private readonly IProductoExternoService _productoExternoService;
        private readonly StockService _stockService;

        public EditarTransaccionUseCase(ITransaccionRepository transaccionRepository, IMapper mapper, IProductoExternoService productoExternoService,
            StockService stockService)
        {
            _transaccionRepository = transaccionRepository;
            _mapper = mapper;
            _productoExternoService = productoExternoService;
            _stockService = stockService;
        }

        public async Task<RespuestaGenerica<TransaccionVerDTO>> EditarTransaccion(Guid id,TransaccionEditarDTO dto)
        {
            try
            {
                Transaccion obtenerTransaccion = await _transaccionRepository.ObtenerTransaccionPorId(id);
                if (obtenerTransaccion == null)
                {
                    return new RespuestaGenerica<TransaccionVerDTO>($"No se ha encontrado la transacción con el id {id.ToString()}", false, null);
                }

                //validar si el producto existe
                ProductoVerDTO producto = await _productoExternoService.ObtenerProductoId(dto.ProductoId);
                if (producto == null)
                {
                    return new RespuestaGenerica<TransaccionVerDTO>("El producto no existe", false, null);
                }
                //validar cuando sea venta, si hay suficiente stock
                bool validarStock = await _productoExternoService.ValidarStockProducto(dto.ProductoId, dto.Cantidad, dto.TipoTransaccion);
                if (!validarStock)
                {

                    return new RespuestaGenerica<TransaccionVerDTO>("No hay suficiente stock del producto para la venta", false, null);
                }
                //Actualizar stock producto
                var actualizarStockProducto = await _productoExternoService.EditarProducto(dto.ProductoId, new ProductoEditarDTO
                {
                    Stock = _stockService.ProcesarStock(producto.stock, dto.Cantidad, dto.TipoTransaccion),
                    Descripcion = producto.descripcion,
                    NombreProducto = producto.nombreProducto,
                    EsActivo = producto.esActivo,
                    Imagen = producto.imagen,
                    Precio = producto.precio,
                    IdCategoria = producto.CategoriaProducto.CategoriaId
                });

                var mapTransaccion = _mapper.Map(dto, obtenerTransaccion);
                mapTransaccion.NombreProducto = producto.nombreProducto;
                mapTransaccion.StockProducto = producto.stock;
                Transaccion crear = await _transaccionRepository.EditarTransaccion(mapTransaccion);
                TransaccionVerDTO transaccionVerDTO = _mapper.Map<TransaccionVerDTO>(crear);
                transaccionVerDTO.NombreProducto = producto.nombreProducto;
                transaccionVerDTO.StockProducto = producto.stock;

                return new RespuestaGenerica<TransaccionVerDTO>("Transacción editada correctamente", true, transaccionVerDTO);
            }
            catch (Exception ex)
            {
                return new RespuestaGenerica<TransaccionVerDTO>($"Se produjo un error: {ex.Message}", false, null);
            }
            

        }
    }
}
