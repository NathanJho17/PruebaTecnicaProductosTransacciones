using Application.DTOs;
using Application.UsesCases;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly CrearTransaccionUseCase _crearTransaccionUseCase;
        private readonly ListarTransaccionesUseCase _listarTransaccionesUseCase;
        private readonly ObtenerTransaccionUseCase _obtenerTransaccionUseCase;
        private readonly EditarTransaccionUseCase _editarTransaccionUseCase;
        private readonly EliminarTransaccionSoftUseCase _eliminarTransaccionSoftUseCase;

        public TransaccionController(CrearTransaccionUseCase crearTransaccionUseCase,
            ListarTransaccionesUseCase listarTransaccionesUseCase,
            ObtenerTransaccionUseCase obtenerTransaccionUseCase,
            EditarTransaccionUseCase editarTransaccionUseCase,
            EliminarTransaccionSoftUseCase eliminarTransaccionSoftUseCase
            )
        {
            _crearTransaccionUseCase = crearTransaccionUseCase;
            _listarTransaccionesUseCase = listarTransaccionesUseCase;
            _obtenerTransaccionUseCase = obtenerTransaccionUseCase;
            _editarTransaccionUseCase = editarTransaccionUseCase;
            _eliminarTransaccionSoftUseCase = eliminarTransaccionSoftUseCase;
        }

        [HttpPost]
        public async Task<ActionResult<RespuestaGenerica<TransaccionVerDTO>>> CrearTransaccion(TransaccionCrearDTO dto)
        {
            RespuestaGenerica<TransaccionVerDTO> respuesta = await _crearTransaccionUseCase.CrearTransaccion(dto);

            return CreatedAtAction(nameof(ObtenerTransaccion),new {id= respuesta .Datos.IdentificadorUnico},respuesta);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TransaccionVerDTO>> ObtenerTransaccion([FromRoute] Guid id)
        {
            RespuestaGenerica<TransaccionVerDTO> respuesta=await _obtenerTransaccionUseCase.ObtenerTransaccionPorId(id);

            return Ok(respuesta);
        }

        [HttpGet]
        public async Task<ActionResult<List<TransaccionVerDTO>>> ListaTransacciones([FromQuery] BuscarTransaccionDTO busqueda)
        {
            RespuestaGenerica<List<TransaccionVerDTO>> respuesta = await _listarTransaccionesUseCase.ListarTransacciones(busqueda.ProductoId, busqueda.Desde,
                busqueda.Limite, busqueda.FechaDesde, busqueda.FechaHasta, busqueda.TipoTransaccion);

            return Ok(respuesta);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TransaccionVerDTO>> EditarTransaccion([FromRoute] Guid id,TransaccionEditarDTO dto)
        {
            RespuestaGenerica<TransaccionVerDTO> respuesta = await _editarTransaccionUseCase.EditarTransaccion(id,dto);

            return Ok(respuesta);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<bool>> EliminarTransaccion([FromRoute] Guid id)
        {
            RespuestaGenerica<bool> respuesta = await _eliminarTransaccionSoftUseCase.EliminarTransaccion(id);

            return Ok(respuesta);
        }

    }
}
