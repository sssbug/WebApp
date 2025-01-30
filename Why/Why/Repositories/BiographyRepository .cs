using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Why.Abstract;
using Why.Data;
using Why.Data.Models;

namespace Why.Repositories
{
    public class BiographyRepository : IBiographyDal
    {
        WhyDbContext context = new WhyDbContext();
        public void AddBiography(Biography biography)
        {
            context.Add(biography);
            context.SaveChanges();
        }

        public Biography GetById(int id)
        {
            return context.Biographies.Find(id);
        }

        public List<Biography> ListAllBiography()
        {
            return context.Biographies.ToList();
        }

        public void RemoveBiography(Biography biography)
        {
            if (biography != null)
            {
                context.Remove(biography);
                context.SaveChanges();
            }
            
        }

        public void UpdateBiography(Biography biography)
        {
            context.Attach(biography);
            context.Entry(biography).State = EntityState.Modified;
            context.SaveChanges();
            context.SaveChanges();
        }
    }
}
