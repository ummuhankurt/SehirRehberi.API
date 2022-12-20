using SehirRehberi.API.DataAccess.Abrtract;
using SehirRehberi.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.DataAccess.Concrete
{
    public class EfPhotoDal : EfEntityRepositoryBase<Photo, DataContext>, IPhotoDal
    {
        public List<Photo> GetPhotosByCity(int cityId)
        {
            using (DataContext context = new DataContext())
            {
                var result = context.Photos.Where(p => p.CityId == cityId).ToList();
                return result;
            }
        }

        public City GetCityById(int cityId)
        {
            using (DataContext context = new DataContext())
            {
                var result = context.Cities.FirstOrDefault(c => c.Id == cityId);
                return result;
            }
        }
    }
}
