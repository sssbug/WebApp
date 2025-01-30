using System.Collections.Generic;
using Why.Data.Models;

namespace Why.AbstractServices
{
    public interface IUserService
    {
        void UseAdd(User user);
        void UserRemove(User user);
        void UserUpdate(User user);
        List<User> GetList();
        User GetbyId(int id);
    }
}
