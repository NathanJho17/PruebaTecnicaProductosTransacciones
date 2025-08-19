using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStockStrategy
    {
        int ActualizarStock(int stockActual, int cantidad);
    }
}
