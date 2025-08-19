using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TransaccionVerDTO
    {
        public Guid IdentificadorUnico { get; set; }
        public bool EsActivo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public  string TipoTransaccion { get; set; }

        public string NombreProducto { get; set; }
        public int StockProducto { get; set; }


        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotal { get; set; }

        public string Detalle { get; set; }
    }
}
