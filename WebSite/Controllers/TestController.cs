using Common;
using Common.DTO;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class TestController : Controller
    {
        public ActionResult GetProducts()
        {
            try
            {
                string path = ConfigurationManager.AppSettings["ApiServie"];
                if (string.IsNullOrEmpty(path))
                    throw new Exception("No se encontró la ruta del servicio");
                var client = new RestClient($"{path}");
                var request = new RestRequest($"GetProducts", Method.GET);
                var response = client.Execute(request);

                var result = JsonConvert.DeserializeObject<IEnumerable<ProductsDto>>(response.Content);

                return View(new ProductsViewModel() { products = result });


            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Login(LoginModel model)
        {
            try
            {
                string path = ConfigurationManager.AppSettings["ApiServie"];
                if (string.IsNullOrEmpty(path))
                    throw new Exception("No se encontró la ruta del servicio");

                var client = new RestClient($"{path}");
                var request = new RestRequest($"GetUser", Method.GET);
                request.AddParameter("name", model.Nombre);
                request.AddParameter("password", model.Password);

                var response = client.Execute(request);
                var deserializedObj = JsonConvert.DeserializeObject<UsersDto>(response.Content);
                if (deserializedObj != null)
                {
                    return RedirectToAction("GetProducts", "Test");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}