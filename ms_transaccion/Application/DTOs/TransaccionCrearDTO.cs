using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TransaccionCrearDTO
    {

        [Required(ErrorMessage = "El Tipo del transacción es obligatoria.")]
        public required string TipoTransaccion { get; set; }

        [Required(ErrorMessage = "El id del producto es obligatorio.")]
        public int ProductoId { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        [Required(ErrorMessage = "La Cantidad de la transacción es obligatoria.")]
        public int Cantidad { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El PrecioUnitario debe ser mayor que cero.")]
        [Required(ErrorMessage = "El stock del producto es obligatorio.")]
        public decimal PrecioUnitario { get; set; }

        public string Detalle { get; set; }
       
    }
}
