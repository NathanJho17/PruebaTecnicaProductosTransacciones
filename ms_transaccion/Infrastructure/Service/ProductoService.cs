using Application.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class ProductoService : IProductoExternoService
    {
        private readonly HttpClient _httpClient;
        private string rutaApiProducto;
        public ProductoService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ApiProductos");
            rutaApiProducto = "/api/Producto";

        }

        public async Task<ProductoVerDTO?> EditarProducto(int productoId,ProductoEditarDTO producto)
        {
           HttpResponseMessage response= await  _httpClient.PutAsJsonAsync($"{rutaApiProducto}/{productoId}", producto);

            if (response.IsSuccessStatusCode)
            {

                RespuestaGenerica<ProductoVerDTO>? respuesta =await  response.Content.ReadFromJsonAsync<RespuestaGenerica<ProductoVerDTO>>();
                return respuesta?.Datos;
            }

            return null;

        }

        public async  Task<ProductoVerDTO?> ObtenerProductoId(int productoId)
        {
            RespuestaGenerica<ProductoVerDTO>? respuesta = await _httpClient.GetFromJsonAsync<RespuestaGenerica<ProductoVerDTO>?>($"{rutaApiProducto}/{productoId}");

            if (respuesta.EsSatisfatorio)
            {
                return respuesta.Datos;
            }
            return null;
        }

        public async Task<bool> ValidarStockProducto(int productoId, int cantidad, string Transaccion)
        {
            RespuestaGenerica<ProductoVerDTO>? respuesta = await _httpClient.GetFromJsonAsync<RespuestaGenerica<ProductoVerDTO>?>($"{rutaApiProducto}/{productoId}");
            ProductoVerDTO? producto = respuesta?.Datos;

            if (Transaccion.ToUpper().Equals(TipoTransaccion.VENTA.ToString()))
            {
                return producto?.stock >= cantidad;
            }
            return true;
        }
    }
}
