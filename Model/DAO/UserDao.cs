using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{   
    
    public class UserDao
    {
        WebShopOnlDbContext db = null;
        public UserDao()
        {
            db = new WebShopOnlDbContext();
        }

        public long Insert(UserAcc entity)
        {
            db.UserAccs.Add(entity);
            db.SaveChanges();
            return entity.UserID;
        }

        public UserAcc GetById(string userName)
        {
            return db.UserAccs.SingleOrDefault(x => x.UserName == userName);
        }

        public UserAcc ViewDetail(int id)
        {
            return db.UserAccs.Find(id);
        }

        //Phan trang
        public IEnumerable<UserAcc> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<UserAcc> model = db.UserAccs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);

            
        }
        // Cap nhat nguoi dung
        public bool Update(UserAcc entity)
        {
            try
            {
                var user = db.UserAccs.Find(entity.UserID);
                user = entity;
                user.ModifiedDate = DateTime.Now;
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
                var user = db.UserAccs.Find(id);
                db.UserAccs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public int Login(string userName, string passWord)
        {
            var result = db.UserAccs.SingleOrDefault(x => x.UserName == userName && x.Password == passWord);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if(result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                        
                }
            }

            
        }

        public bool CheckUserName(string userName)
        {
            if (db.UserAccs.Count(x => x.UserName == userName) > 0)

                return true;
            else
                return false;
        }
        public bool CheckEmail(string email)
        {
            return db.UserAccs.Count(x => x.Email == email) > 0;
        }
    }
}
