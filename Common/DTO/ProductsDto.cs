using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class ProductsDto : ResponseDto
    {
        public int IdProduct { get; set; }
        public Nullable<int> IdTypeProduct { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> Costo { get; set; }
    }
}
