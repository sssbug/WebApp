using System.Collections.Generic;
using Why.Data.Models;

namespace Why.AbstractServices
{
    public interface ICategoryService
    {
        void CategoryAdd(Category category);
        void CategoryRemove(Category category);
        void CategoryUpdate(Category category);
        List<Category> GetList();
        Category GetbyId(int id);
    }
}
