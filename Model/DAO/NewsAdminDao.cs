using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class NewsAdminDao
    {
        WebShopOnlDbContext db = null;
        public NewsAdminDao()
        {
            db = new WebShopOnlDbContext();
        }

        public News ViewDetail(long id)
        {
            return db.News.Find(id);
        }

        public long Insert(News entity)
        {
            db.News.Add(entity);
            db.SaveChanges();
            return entity.NewsID;
        }

        public IEnumerable<News> ListAllNews(string searchString, int page, int pageSize)
        {
            IQueryable<News> model = db.News;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.NewsID).ToPagedList(page, pageSize);

        }

        public bool Delete(int id)
        {
            try
            {
                var news = db.News.Find(id);
                db.News.Remove(news);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(News entity)
        {
            try
            {
                var News = db.News.FirstOrDefault(x => x.NewsID == entity.NewsID);
                News = entity;
                News.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }

        }
    }
}
