using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopOnl.Common;
using WebShopOnl.Models;
using PagedList;
using PagedList.Mvc;
namespace WebShopOnl.Controllers
{
    public class HomeController : Controller
    {
        WebShopOnlDbContext db = new WebShopOnlDbContext();
        // GET: Home
        public ActionResult Index()
        {
            
            var productDao = new ProductDao();
            
            ViewBag.NewsProducts = productDao.ListNewProduct(8);
            ViewBag.HotProducts = productDao.ListHotProduct();

            return View();
        }

        
        // GET: Cart
        public ActionResult HeaderCart()
        {
            var cart = Session[ComonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

    }
}