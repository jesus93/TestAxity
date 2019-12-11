using Common;
using Common.DTO;
using DAL_AXITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [RoutePrefix("Axity/api")]
    [EnableCors("*","*","*")]
    public class AxityTestCotnroller : System.Web.Http.ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        [Route("GetUser")]
        public IHttpActionResult GetUser(string name, string password)
        {
            try
            {
                var result =
                unitOfWork.UsersRepository.Get(
                    filter: item => item.Nombre.Trim().ToLower() == name.Trim().ToLower() &&
                                    item.Contrasenia.Trim().ToLower() == password.Trim().ToLower()
                    
                    )?.Select(item => new UsersDto() {
                        Nombre = item.Nombre,
                        Contrasenia = item.Contrasenia,
                        IdUser = item.IdUser,
                        
                    })?.FirstOrDefault();

                if (result == null)
                    return Ok(new UsersDto { Message = "No hay coincidencias", HasError = true });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new UsersDto() { Message = ex?.Message, HasError = true });
            }
        }

        [Route("GetProducts")]
        public IHttpActionResult GetProduct()
        {
            try
            {
                var result = unitOfWork.ProductsRepository.Get()?.Select(item  => new ProductsDto()
                {
                    Nombre = item.Nombre,
                    Costo = item.Costo,
                    IdProduct = item.IdProduct,
                    IdTypeProduct = item.IdTypeProduct
                });
                if (result == null)
                    return Ok(new ProductsDto { Message = "No hay coincidencias", HasError = true });

                return Ok(result);
            }
            catch(Exception ex)
            {
                return Ok(new UsersDto() { Message = ex?.Message, HasError = true });

            }
        }
    }
}