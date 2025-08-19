using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UsesCases
{
    public class ObtenerTransaccionUseCase
    {
        private readonly ITransaccionRepository _transaccionRepository;
        private readonly IMapper _mapper;

        public ObtenerTransaccionUseCase(ITransaccionRepository transaccionRepository, IMapper mapper)
        {
            _transaccionRepository = transaccionRepository;
            _mapper = mapper;
        }


        public async Task<RespuestaGenerica<TransaccionVerDTO>> ObtenerTransaccionPorId(Guid guidTransaccion)
        {
            try
            {
                Transaccion transaccion = await _transaccionRepository.ObtenerTransaccionPorId(guidTransaccion);
                if (transaccion == null)
                {
                    return new RespuestaGenerica<TransaccionVerDTO>("No existe la transacción", false, null);
                }

                var mapTransaccion = _mapper.Map<TransaccionVerDTO>(transaccion);

                return new RespuestaGenerica<TransaccionVerDTO>("Transacción encontrada exitosamente", true, mapTransaccion);
            }
            catch (Exception ex)
            {

                return new RespuestaGenerica<TransaccionVerDTO>($"Se produjo un error: {ex.Message}", false, null);
            }
           
        }
    }
}
