using Application.DTOs;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductoExternoService
    {
        Task<ProductoVerDTO> ObtenerProductoId(int idproductoId);

        Task<ProductoVerDTO> EditarProducto(int productoId, ProductoEditarDTO producto);

        Task<bool> ValidarStockProducto(int productoId,int cantidad, string Transaccion);
    }
}
