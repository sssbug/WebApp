using System.Collections.Generic;
using Why.Data.Models;

namespace Why.AbstractServices
{
    public interface IThumbService
    {
        void ThumbAdd(Thumb thumb);
        void ThumbRemove(Thumb thumb);
        void ThumbUpdate(Thumb thumb);
        List<Thumb> GetList();
        Thumb GetbyId(int id);
    }
}
