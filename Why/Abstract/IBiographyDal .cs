using System.Collections.Generic;
using Why.Data.Models;

namespace Why.Abstract
{
    public interface IBiographyDal
    {
        List<Biography> ListAllBiography();
        void AddBiography(Biography biography);
        void RemoveBiography(Biography biography);
        void UpdateBiography(Biography biography);
        Biography GetById(int id);
    }
}
