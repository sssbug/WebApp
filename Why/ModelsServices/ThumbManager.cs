using System.Collections.Generic;
using Why.Abstract;
using Why.AbstractServices;
using Why.Data.Models;
using Why.Repositories;

namespace Why.ModelsServices
{
    public class ThumbManager : IThumbService
    {
        IThumbDal _ThumbDal;

        public ThumbManager(IThumbDal ThumbDal)
        {
            _ThumbDal = ThumbDal;
        }

        public Thumb GetbyId(int id)
        {
          return _ThumbDal.GetById(id);
        }

        public List<Thumb> GetList()
        {
            return _ThumbDal.ListAllThumb();
        }

        public void ThumbAdd(Thumb thumb)
        {
            _ThumbDal.AddThumb(thumb);
        }

        public void ThumbRemove(Thumb thumb)
        {
            _ThumbDal.RemoveThumb(thumb);
        }

        public void ThumbUpdate(Thumb thumb)
        {
            _ThumbDal.UpdateThumb(thumb);
        }
    }
}
