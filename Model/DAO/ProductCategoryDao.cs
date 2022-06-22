using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{
    public class ProductCategoryDao
    {
        WebShopOnlDbContext db = null;
        public ProductCategoryDao()
        {
            db = new WebShopOnlDbContext();
        }

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }

        //Phan trang
        public IEnumerable<ProductCategory> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.MetaTitle.Contains(searchString));
            }

            return model.OrderBy(x => x.CategoryID).ToPagedList(page, pageSize);

            //return db.ProductCategoryAccs.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public long Insert(ProductCategory entity)
        {
            db.ProductCategories.Add(entity);
            db.SaveChanges();
            return entity.CategoryID;
        }

        // Cap nhat
        public bool Update(ProductCategory entity)
        {
            try
            {
                var ProductCategory = db.ProductCategories.FirstOrDefault(x => x.CategoryID == entity.CategoryID);
                ProductCategory = entity;
                ProductCategory.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        //delete

        public bool Delete(int id)
        {
            try
            {
                var ProductCategory = db.ProductCategories.Find(id);
                var products = db.Products.ToList();
                if (products.Count != 0)
                {
                    foreach(var item in products)
                    {
                        if (item.CategoryID == ProductCategory.CategoryID)
                            db.Products.Remove(item);
                    }
                }
                db.ProductCategories.Remove(ProductCategory);
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
