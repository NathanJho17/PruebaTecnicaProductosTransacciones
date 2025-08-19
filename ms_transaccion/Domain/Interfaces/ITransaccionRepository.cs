using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITransaccionRepository
    {
        Task<Transaccion?> CrearTransaccion(Transaccion Transaccion);

        Task<List<Transaccion>> ListarTransacciones(int productoId, int desde, int limite,DateTime? fechaDesde, DateTime? fechaHasta,
            string tipoTransaccion);

        Task<Transaccion> EditarTransaccion(Transaccion Transaccion);

        Task<Transaccion?> ObtenerTransaccionPorId(Guid TransaccionId);
        Task<bool> BorrarTransaccionSoft(Transaccion Transaccion);
    }
}
