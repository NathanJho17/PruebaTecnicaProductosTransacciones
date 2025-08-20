using Application.DTOs;
using Application.UsesCases;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ListarCategoriaUseCase _listarCategoriaUseCase;

        public CategoriaController(ListarCategoriaUseCase listarCategoriaUseCase)
        {
            _listarCategoriaUseCase = listarCategoriaUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<RespuestaGenerica<List<CategoriaVerDTO>>>> ListarCtegorias()
        {
            RespuestaGenerica<List<CategoriaVerDTO>> respuesta = await _listarCategoriaUseCase.ListarCategorias();
            return Ok(respuesta);
        }
    }
}
