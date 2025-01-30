using System.Collections.Generic;
using Why.Data.Models;

namespace Why.Abstract
{
    public interface IThumbDal
    {
        List<Thumb> ListAllThumb();
        void AddThumb(Thumb thumb);
        void RemoveThumb(Thumb thumb);
        void UpdateThumb(Thumb thumb);
        Thumb GetById(int id);
    }
}
