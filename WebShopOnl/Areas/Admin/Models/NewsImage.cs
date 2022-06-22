using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopOnl.Areas.Admin.Models
{
    public class NewsImage
    {
        public News News { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }
}