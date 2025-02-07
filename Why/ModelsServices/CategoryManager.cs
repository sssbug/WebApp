using System.Collections.Generic;
using Why.Abstract;
using Why.AbstractServices;
using Why.Data.Models;
using Why.Repositories;

namespace Why.ModelsServices
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void CategoryAdd(Category category)
        {
            if (category.CategoryName != "" && category.CategoryName.Length >= 5 )
            {
                _categoryDal.AddCategory(category);
            }
            else
            {
                //Hata
            }
            
        }

        public void CategoryRemove(Category category)
        {
            _categoryDal.RemoveCategory(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.UpdateCategory(category);
        }

        public Category GetbyId(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.ListAllCategory();
        }
    }
}
