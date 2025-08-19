using Application;
using Application.DTOs;
using Application.UsesCases;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly CrearProductoUseCase crearProductoUseCase;
        private readonly EditarProductoCase editarProductoCase;
        private readonly ListarProductosUseCase listarProductosUseCase;
        private readonly EliminarProductoSoftUseCase eliminarProductoSoftUseCase;
        private readonly ObtenerProductoIdCase obtenerProductoIdCase;

        public ProductoController(CrearProductoUseCase crearProductoUseCase,
            EditarProductoCase editarProductoCase,
            ListarProductosUseCase listarProductosUseCase,
            EliminarProductoSoftUseCase eliminarProductoSoftUseCase,
            ObtenerProductoIdCase obtenerProductoIdCase
            )
        {
            this.crearProductoUseCase = crearProductoUseCase;
            this.editarProductoCase = editarProductoCase;
            this.listarProductosUseCase = listarProductosUseCase;
            this.eliminarProductoSoftUseCase = eliminarProductoSoftUseCase;
            this.obtenerProductoIdCase = obtenerProductoIdCase;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RespuestaGenerica<ProductoVerDTO>>> ObtenerProductoPorId([FromRoute] int id)
        {
            RespuestaGenerica<ProductoVerDTO> respuesta = await obtenerProductoIdCase.ObtenerProducto(id);
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<ActionResult<RespuestaGenerica<ProductoVerDTO>>> CrearProducto(ProductoCrearDTO dto)
        {
            RespuestaGenerica<ProductoVerDTO> respuesta = await crearProductoUseCase.Crear(dto);
            ProductoVerDTO? producto = respuesta.Datos as ProductoVerDTO;
                return CreatedAtAction(
                nameof(ObtenerProductoPorId),   
                new { id = producto?.ProductoId }, 
                respuesta              
            );
        }

        [HttpGet]
        public async Task<ActionResult<RespuestaGenerica<List<ProductoVerDTO>>>> ListarProductos([FromQuery] int desde,int limite)
        {
            RespuestaGenerica<List<ProductoVerDTO>> respuesta = await listarProductosUseCase.Listar(desde,limite);
            return Ok(respuesta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RespuestaGenerica<ProductoVerDTO>>> EditarProducto([FromRoute]int id,[FromBody] ProductoEditarDTO dto)
        {
            RespuestaGenerica<ProductoVerDTO> respuesta = await editarProductoCase.Editar(id,dto);
            return Ok(respuesta);
        
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<RespuestaGenerica<bool>>> EliminarProducto([FromRoute] int id)
        {
            RespuestaGenerica<bool> respuesta = await eliminarProductoSoftUseCase.EliminarSoft(id);
            return Ok(respuesta);

        }

    }
}
