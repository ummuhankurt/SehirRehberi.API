using SehirRehberi.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.DataAccess.Abrtract
{
    public interface ICityDal : IEntityRepository<City>
    {
        List<City> GetCitiesDetails();
        City GetCitiesDetailsById(int id);
    }
}
