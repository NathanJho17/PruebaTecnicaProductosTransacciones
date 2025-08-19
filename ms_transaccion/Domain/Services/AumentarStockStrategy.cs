using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AumentarStockStrategy : IStockStrategy
    {
        public int ActualizarStock(int stockActual, int cantidad) => stockActual + cantidad;
    }
}
