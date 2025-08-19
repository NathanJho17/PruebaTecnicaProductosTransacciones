using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class StockService
    {
        private readonly StockStrategyFactory _factory;
        public StockService(StockStrategyFactory factory)
        {
            _factory = factory;
        }

        public int ProcesarStock(int stockActual, int cantidad, string tipo)
        {

            if (tipo.Equals("venta"))
            {
                var estrategia = _factory.ObtenerStrategy(TipoTransaccion.VENTA);
                return estrategia.ActualizarStock(stockActual, cantidad);
            }
            else
            {
                var estrategiac = _factory.ObtenerStrategy(TipoTransaccion.COMPRA);
                return estrategiac.ActualizarStock(stockActual, cantidad);
            }
        

        }
    }
}
