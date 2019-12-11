using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<ProductsDto> products { get; set; }
    }
}