using System.Collections.Generic;
using Why.Data.Models;

namespace Why.AbstractServices
{
    public interface IBiographyService
    {
        void BiographyAdd(Biography biography);
        void BiographyRemove(Biography biography);
        void BiographyUpdate(Biography biography);
        List<Biography> GetList();
        Biography GetbyId(int id);
    }
}
