using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Why.Abstract;
using Why.Data;
using Why.Data.Models;

namespace Why.Repositories
{
    public class ThumbRepository : IThumbDal
    {
        WhyDbContext context = new WhyDbContext();
        public void AddThumb(Thumb thumb)
        {
            context.Add(thumb);
            context.SaveChanges();
        }

        public Thumb GetById(int id)
        {
            return context.Thumbs.Find(id);
        }

        public List<Thumb> ListAllThumb()
        {
            return context.Thumbs.ToList();
        }

        public void RemoveThumb(Thumb thumb)
        {
            context.Remove(thumb);
            context.SaveChanges();
        }

        public void UpdateThumb(Thumb thumb)
        {
            context.Attach(thumb);
            context.Entry(thumb).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
