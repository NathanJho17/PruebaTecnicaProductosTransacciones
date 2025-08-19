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
    public class ListarTransaccionesUseCase
    {
        private readonly ITransaccionRepository _transaccionRepository;
        private readonly IMapper _mapper;

        public ListarTransaccionesUseCase(ITransaccionRepository transaccionRepository, IMapper mapper)
        {
            _transaccionRepository = transaccionRepository;
            _mapper = mapper;
        }


        public async Task<RespuestaGenerica<List<TransaccionVerDTO>>> ListarTransacciones(int productoId,int desde, int limite, DateTime? fechaDesde,DateTime? fechaHasta,string tipoTransaccion)
        {
            try
            {
                List<Transaccion> listarTransacciones = await _transaccionRepository.ListarTransacciones(productoId, desde, limite, fechaDesde, fechaHasta, tipoTransaccion);

                var mapTransacciones = _mapper.Map<List<TransaccionVerDTO>>(listarTransacciones);

                return new RespuestaGenerica<List<TransaccionVerDTO>>($"Total transacciones obtenidos {mapTransacciones.Count}", true, mapTransacciones);
            }
            catch (Exception ex)
            {
                return new RespuestaGenerica<List<TransaccionVerDTO>>($"Se produjo un error: {ex.Message}", false, null);
            }
           
        }
    }
}
