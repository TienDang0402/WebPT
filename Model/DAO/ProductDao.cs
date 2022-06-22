using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.DAO
{
    public class ProductDao
    {
        WebShopOnlDbContext db = null;
        public ProductDao()
        {
            db = new WebShopOnlDbContext();
        }

        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderBy(x => x.ID).Take(top).ToList();
        }

        public List<Product> ListHotProduct()
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.ID).ToList();
        }

        public List<Product> ListProduct(long CategoryID)
        {
            return db.Products.Where(x => x.CategoryID == CategoryID).OrderBy(x => x.ID).ToList();
        }

        public List<Product> ListRelatedProducts(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).ToList();
        }

        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

        //
        public List<string> ListName(string keyword)
        {
            
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }

        // tim kiem
        public List<Product> Search(string keyword, ref int totalRecord, int pageIndex, int pageSize)
        {
            totalRecord = db.Products.Where(x => x.Name.Contains(keyword)).Count();
            var model = db.Products.Where(x => x.Name.Contains(keyword));
            model.OrderByDescending(x => x.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();

            
        }

        //Phan trang
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Code.Contains(searchString));
            }

            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);

            
        }

        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        // Cap nhat
        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.FirstOrDefault(x => x.ID == entity.ID);
                product = entity;
                product.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }

        }
        //delete

        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
