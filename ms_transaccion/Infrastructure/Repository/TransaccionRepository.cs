using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TransaccionRepository : ITransaccionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransaccionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> BorrarTransaccionSoft(Transaccion Transaccion)
        {
            try
            {
                _context.Transaccion.Update(Transaccion);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw new Exception("Error al eliminar la transacción");
            }
        }

        public async Task<Transaccion?> CrearTransaccion(Transaccion transaccion)
        {
            try
            {
                await _context.AddAsync(transaccion);
                await _context.SaveChangesAsync();

                return transaccion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la transacción", ex);
            }
        }

        public async Task<Transaccion> EditarTransaccion(Transaccion Transaccion)
        {
            try
            {
                _context.Transaccion.Update(Transaccion);
                await _context.SaveChangesAsync();
                return Transaccion;
            }
            catch (Exception)
            {

                throw new Exception("Error al editar el producto");
            }
        }

        public async Task<List<Transaccion>> ListarTransacciones(int productoId,int desde, int limite, DateTime? fechaDesde, DateTime? fechaHasta,
             string tipoTransaccion)
        {
            try
            {
                    var transacciones = await _context.Transaccion
                        .Where(p => p.Activo == true &&
                       p.ProductoId== productoId)
                       .Skip(((desde == 0) ? 1 : desde - 1) * limite)
                        .Take(limite)
                        .ToListAsync();

                if (!string.IsNullOrWhiteSpace(tipoTransaccion))
                {
                    return transacciones
                      .Where(t => t.Tipo.Equals(tipoTransaccion))
                      .ToList();
                }
                if (fechaDesde!=null && fechaHasta!=null)
                {
                    return transacciones.Where(t=>
                       t.FechaCreacion >= fechaDesde && t.FechaCreacion <= fechaHasta)
                       .ToList();
                }

                return transacciones;
            }
            catch (System.Exception)
            {

                throw new Exception("Error al obtener listado de transacciones");
            }
        }

        public async Task<Transaccion?> ObtenerTransaccionPorId(Guid TransaccionId)
        {
            try
            {
                Transaccion? encontrado =
                await _context.Transaccion.Where(p => p.Id.Equals(TransaccionId)).FirstOrDefaultAsync();
                  

                return encontrado;
            }
            catch (Exception)
            {

                throw new Exception("Error al obtener el transacción");
            }
        }
    }
}
