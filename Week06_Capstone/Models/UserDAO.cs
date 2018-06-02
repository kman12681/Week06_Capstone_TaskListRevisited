using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week06_Capstone.Models
{
    public class UserDAO
    {
       
        
            private TaskListEntities db;

            public UserDAO()
            {
                db = new TaskListEntities();
            }

            public User GetUser(int id)
            {
                return db.Users.Find(id);
            }

            public List<User> GetUserList()
            {
                return db.Users.ToList();
            }

            public void AddUser(User user)
            {
                db.Users.Add(user);
                db.SaveChanges();

            }
          

            public void Dispose()
            {
                {
                    db.Dispose();
                }

            }


        

    }
}