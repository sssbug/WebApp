using System.Collections.Generic;
using Why.Data.Models;

namespace Why.Abstract
{
    public interface IUserDal
    {
        List<User> ListAllUser();
        void AddUser(User user);
        void RemoveUser(User user);
        void UpdateUser(User user);
        User GetById(int id);
    }
}
