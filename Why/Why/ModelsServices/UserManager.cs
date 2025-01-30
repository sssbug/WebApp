using System.Collections.Generic;
using Why.Abstract;
using Why.AbstractServices;
using Why.Data.Models;
using Why.Repositories;

namespace Why.ModelsServices
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void UserRemove(User user)
        {
            _userDal.RemoveUser(user);
        }

        public void UserUpdate(User user)
        {
            _userDal.UpdateUser(user);
        }

        public User GetbyId(int id)
        {
            return _userDal.GetById(id);
        }

        public List<User> GetList()
        {
            return _userDal.ListAllUser();
        }

        public void UseAdd(User user)
        {
            _userDal.AddUser(user);
        }
    }
}
