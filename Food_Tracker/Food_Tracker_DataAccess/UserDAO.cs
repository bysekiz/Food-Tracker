using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Food_Tracker_DataAccess
{
    public class UserDAO
    {
        public void UserRegister(tblUser item)
        {
            using (FoodTrackerDBEntities db = new FoodTrackerDBEntities())
            {
                db.tblUser.Add(item);
                db.SaveChanges();
            }
        }

        public tblUser GetUser(string email, string password)
        {
            using (FoodTrackerDBEntities db = new FoodTrackerDBEntities())
            {
                
                return (from u in db.tblUser
                        where u.Email == email && u.Password == password
                        select u).SingleOrDefault<tblUser>();
            }
        }
    }
}
