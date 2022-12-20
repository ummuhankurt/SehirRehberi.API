using SehirRehberi.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.DataAccess.Abrtract
{
    public interface IPhotoDal : IEntityRepository<Photo>
    {
        List<Photo> GetPhotosByCity(int cityId);
        City GetCityById(int cityId);
    }
}
