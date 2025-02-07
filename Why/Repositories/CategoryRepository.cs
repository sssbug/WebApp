using System.Collections.Generic;
using System.Linq;
using Why.Abstract;
using Why.Data;
using Why.Data.Models;

namespace Why.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        WhyDbContext context = new WhyDbContext();
        public void AddCategory(Category category)
        {
            context.Add(category);
            context.SaveChanges();
        }

        public Category GetById(int id)
        {
            return context.Categories.Find(id);
        }

        public List<Category> ListAllCategory()
        {
            return context.Categories.ToList();
        }

        public void RemoveCategory(Category category)
        {
            context.Remove(category);
            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            context.Update(category);
            context.SaveChanges();
        }
    }
}
