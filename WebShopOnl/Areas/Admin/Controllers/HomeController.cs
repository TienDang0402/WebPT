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
    public class HomeController : BaseController
    {

        WebShopOnlDbContext db = new WebShopOnlDbContext();
        // GET: Admin/Home
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            
            var dao = new OrderDao();
            var model = dao.ListAllOrder(searchString, page, pageSize);
            var orderDetail = new OrderDetailDao();
            ViewBag.SearchOrder = searchString;

            

            return View(model);
        }
        //xem chi tiet hoa don
        public ActionResult Detail(long id=1)
        {
            List<OrderDetail> lsOrderDetail = db.OrderDetails.Where(x => x.OrderID == id).OrderBy(x => x.ID).ToList();
            ViewBag.OrDetail = db.Orders.Find(id);
            return View(lsOrderDetail);
        }
        [HttpPost]
        
        public JsonResult ChangeStatus(long id)
        {
            var result = new OrderDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}