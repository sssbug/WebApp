using System.Collections.Generic;
using Why.Abstract;
using Why.AbstractServices;
using Why.Data.Models;
using Why.Repositories;

namespace Why.ModelsServices
{
    public class BiographyManager : IBiographyService
    {
        IBiographyDal _biographyDal;

        public BiographyManager(IBiographyDal biographyDal)
        {
            _biographyDal = biographyDal;
        }

        public void BiographyRemove(Biography biography)
        {
            _biographyDal.RemoveBiography(biography);
        }

        public void BiographyUpdate(Biography biography)
        {
            _biographyDal.UpdateBiography(biography);
        }

        public Biography GetbyId(int id)
        {
            return _biographyDal.GetById(id);
        }

        public List<Biography> GetList()
        {
            return _biographyDal.ListAllBiography();
        }

        public void BiographyAdd(Biography biography)
        {
            _biographyDal.AddBiography(biography);
        }
    }
}
