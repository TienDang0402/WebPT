using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;
using WebShopOnl.Areas.Admin.Models;

namespace WebShopOnl.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductImage ProductImage)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();

                string fileName = Path.GetFileNameWithoutExtension(ProductImage.ImageFile.FileName);
                string extension = Path.GetExtension(ProductImage.ImageFile.FileName);
                fileName = fileName + extension;
                ProductImage.Product.Images = fileName;
                fileName = Path.Combine(Server.MapPath("~/assets/client/images/"), fileName);
                ProductImage.ImageFile.SaveAs(fileName);

                long id = dao.Insert(ProductImage.Product);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Index");
        }

        //edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Product = new ProductDao().ViewDetail(id);
            ProductImage pi = new ProductImage();
            pi.Product = new Product();
            pi.Product.ID = Product.ID;
            pi.Product.Name = Product.Name;
            pi.Product.Code = Product.Code;
            pi.Product.Price = Product.Price;
            pi.Product.Quantity = Product.Quantity;
            pi.Product.CategoryID = Product.CategoryID;
            pi.Product.ModifiedBy = Product.ModifiedBy;
            pi.Product.ModifiedDate = Product.ModifiedDate;
            return View(pi);
        }

        [HttpPost]
        public ActionResult Edit(ProductImage ProductImage)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();

                string fileName = Path.GetFileNameWithoutExtension(ProductImage.ImageFile.FileName);
                string extension = Path.GetExtension(ProductImage.ImageFile.FileName);
                fileName = fileName + extension;
                ProductImage.Product.Images = fileName;
                fileName = Path.Combine(Server.MapPath("~/assets/client/images/"), fileName);
                ProductImage.ImageFile.SaveAs(fileName);

                var result = dao.Update(ProductImage.Product);
                if (result)
                {
                    SetAlert("Sửa Product thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);

            return RedirectToAction("Index");
        }

        
    }
}