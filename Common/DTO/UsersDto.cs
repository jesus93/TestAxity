using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UsersDto : ResponseDto
    {
        public int IdUser { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
    }
}
