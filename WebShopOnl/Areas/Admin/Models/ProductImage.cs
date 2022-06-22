using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopOnl.Areas.Admin.Models
{
    public class ProductImage
    {
        public Product Product { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}