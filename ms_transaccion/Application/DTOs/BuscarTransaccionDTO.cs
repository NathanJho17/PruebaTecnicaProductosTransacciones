using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BuscarTransaccionDTO
    {
        [Required(ErrorMessage ="El id de producto es obligatorio")]
        public int ProductoId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El ProductoId debe ser mayor a 0")]
        [Required(ErrorMessage = "El campo desde es obligatorio")]
        public int Desde { get; set; }
        [Required(ErrorMessage = "El campo desde es obligatorio")]

        public int Limite { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string TipoTransaccion { get; set; } = string.Empty;
    }
}
