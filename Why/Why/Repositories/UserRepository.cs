using System.Collections.Generic;
using System.Linq;
using Why.Abstract;
using Why.Data;
using Why.Data.Models;

namespace Why.Repositories
{
    public class UserRepository : IUserDal
    {
        WhyDbContext context = new WhyDbContext();
        public void AddUser(User user)
        {
            context.Add(user);
            context.SaveChanges();
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public List<User> ListAllUser()
        {
            return context.Users.ToList();
        }

        public void RemoveUser(User user)
        {
            context.Remove(user);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Update(user);
            context.SaveChanges();
        }
    }
}
