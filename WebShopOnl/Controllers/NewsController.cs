using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShopOnl.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            var lstNew = new NewsDao().ListAllNews();
            return View(lstNew);
        }

        public ActionResult Detail(long id)
        {
            var news = new NewsDao().ViewDetail(id);
            return View(news);
        }
    }
}