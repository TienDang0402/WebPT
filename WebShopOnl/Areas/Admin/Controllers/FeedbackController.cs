using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace WebShopOnl.Areas.Admin.Controllers
{
    public class FeedbackController : BaseController
    {

        WebShopOnlDbContext db = new WebShopOnlDbContext();
        // GET: Admin/Feedback
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            
            var dao = new FeedbackDao();
            var model = dao.ListAllFeedback(searchString, page, pageSize);
            //var orderDetail = new OrderDetailDao();
            ViewBag.SearchOrder = searchString;



            return View(model);
        }
    }
}