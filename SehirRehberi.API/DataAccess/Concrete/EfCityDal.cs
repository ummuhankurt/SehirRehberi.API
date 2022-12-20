using Microsoft.EntityFrameworkCore;
using SehirRehberi.API.DataAccess.Abrtract;
using SehirRehberi.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.DataAccess.Concrete
{
    public class EfCityDal : EfEntityRepositoryBase<City, DataContext>, ICityDal
    {
        public List<City> GetCitiesDetails()
        {
            using (DataContext context = new DataContext())
            {
                var result = context.Cities.Include(c => c.Photos).ToList();
                return result;
            }
        }

        public City GetCitiesDetailsById(int id)
        {
            using (DataContext context = new DataContext())
            {
                var result = context.Cities.Include(c => c.Photos).FirstOrDefault(c => c.Id == id);
                return result;
            }
        }
    }
}
