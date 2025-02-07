using System.Collections.Generic;
using Why.Data.Models;

namespace Why.Abstract
{
    public interface ICategoryDal
    {
        List<Category> ListAllCategory();
        void AddCategory(Category category);
        void RemoveCategory(Category category);
        void UpdateCategory(Category category);
        Category GetById(int id);
    }
}
