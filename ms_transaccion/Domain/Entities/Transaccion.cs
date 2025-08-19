using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaccion: PropiedadesGenerica
    {
        [Key]
        public Guid Id { get; set; }

        public string Tipo { get; set; }

        public int ProductoId { get; set; }
        public string? NombreProducto { get; set; }
        public int StockProducto { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal PrecioTotal => Cantidad * PrecioUnitario;

        public string Detalle { get; set; } = null!;

        public Transaccion(Guid Id, string Tipo, int ProductoId,int Cantidad, decimal PrecioUnitario, string Detalle)
        {
            this.Id = Id;
            this.Tipo = Tipo;
            this.ProductoId = ProductoId;
            this.Cantidad = Cantidad;
            this.PrecioUnitario = PrecioUnitario;
            this.Detalle = Detalle;
        }
    }
}
