using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class FeedbackDao
    {
        WebShopOnlDbContext db = null;
        public FeedbackDao()
        {
            db = new WebShopOnlDbContext();
        }

        public List<Feedback> ListAllFeedback()
        {
            return db.Feedbacks.OrderByDescending(x => x.FeedbackId).ToList();
        }

        public IEnumerable<Feedback> ListAllFeedback(string searchString, int page, int pageSize)
        {
            IQueryable<Feedback> model = db.Feedbacks;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Email.Contains(searchString));
            }

            return model.OrderByDescending(x => x.FeedbackId).ToPagedList(page, pageSize);

            //return db.UserAccs.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
    }
}
