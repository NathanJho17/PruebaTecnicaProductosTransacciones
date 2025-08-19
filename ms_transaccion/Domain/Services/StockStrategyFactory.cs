using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class StockStrategyFactory
    {
        private readonly IDictionary<TipoTransaccion, IStockStrategy> _estrategias;

        public StockStrategyFactory(IEnumerable<IStockStrategy> estrategias)
        {
            _estrategias = estrategias.ToDictionary(e =>
            {
                return e switch
                {
                    AumentarStockStrategy => TipoTransaccion.COMPRA,
                    DisminuirStockStrategy => TipoTransaccion.VENTA,
                    _ => throw new ArgumentException("Estrategia no válida...")
                };
            });
        }

        public IStockStrategy ObtenerStrategy(TipoTransaccion tipo)
        {
            return _estrategias[tipo];
        }

    }
}
