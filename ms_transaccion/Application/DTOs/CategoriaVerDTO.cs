using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public  class CategoriaVerDTO
    {
        public string nombreCategoria { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
    }
}
