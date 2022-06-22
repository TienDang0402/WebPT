using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{
    public class OrderDao
    {
        WebShopOnlDbContext db = null;
        public OrderDao()
        {
            db = new WebShopOnlDbContext();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.OrderID;
        }

        public List<Order> ListAllOrder()
        {
            return db.Orders.OrderByDescending(x => x.OrderID).ToList();
        }

        public IEnumerable<Order> ListAllOrder(string searchString, int page, int pageSize)
        {
            IQueryable<Order> model = db.Orders;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipName.Contains(searchString) || x.ShipEmail.Contains(searchString));
            }

            return model.OrderByDescending(x => x.OrderID).ToPagedList(page, pageSize);

            
        }

        public Order ViewDetail(long id)
        {
            return db.Orders.Find(id);
        }

        public int ChangeStatus(long id)
        {
            var order = db.Orders.Find(id);

            if (order.Status == 1)
                order.Status = 0;
            else
                order.Status = 1;
            db.SaveChanges();
            return (int)order.Status;
        }
    }
}
