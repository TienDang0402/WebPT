using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class NewsDao
    {
        WebShopOnlDbContext db = null;
        public NewsDao()
        {
            db = new WebShopOnlDbContext();
        }

        public List<News> ListNews(int top)
        {
            return db.News.OrderByDescending(x => x.NewsID).Take(top).ToList();
        }

        public List<News> ListAllNews()
        {
            return db.News.OrderByDescending(x => x.NewsID).ToList();
        }
        public News ViewDetail(long id)
        {
            return db.News.Find(id);
        }
    }
}
