using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopOnl.Areas.Admin.Models;

namespace WebShopOnl.Areas.Admin.Controllers
{
    public class NewsAdminController : BaseController
    {
        // GET: Admin/NewsAdmin
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new NewsAdminDao();
            var model = dao.ListAllNews(searchString, page, pageSize);
            ViewBag.SearchOrder = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(NewsImage user)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsAdminDao();

                string fileName = Path.GetFileNameWithoutExtension(user.ImageFile.FileName);
                string extension = Path.GetExtension(user.ImageFile.FileName);
                fileName = fileName + extension;
                user.News.Images = fileName;
                fileName = Path.Combine(Server.MapPath("~/assets/client/images/"), fileName);
                user.ImageFile.SaveAs(fileName);

                long id = dao.Insert(user.News);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "NewsAdmin");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new NewsAdminDao().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var News = new NewsAdminDao().ViewDetail(id);
            NewsImage pi = new NewsImage();
            pi.News = new News();
            pi.News = News;
            return View(pi);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NewsImage NewsImage)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsAdminDao();

                string fileName = Path.GetFileNameWithoutExtension(NewsImage.ImageFile.FileName);
                string extension = Path.GetExtension(NewsImage.ImageFile.FileName);
                fileName = fileName + extension;
                NewsImage.News.Images = fileName;
                fileName = Path.Combine(Server.MapPath("~/assets/client/images/"), fileName);
                NewsImage.ImageFile.SaveAs(fileName);

                var result = dao.Update(NewsImage.News);
                if (result)
                {
                    SetAlert("Sửa thành công", "success");
                    return RedirectToAction("Index", "NewsAdmin");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }
    }
}