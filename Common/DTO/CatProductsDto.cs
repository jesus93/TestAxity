using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class CatProductsDto : ResponseDto
    {
        public int IdTypeProduct { get; set; }
        public string Nombre { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}
