using SehirRehberi.API.DataAccess.Abrtract;
using SehirRehberi.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User,DataContext>,IUserDal
    {

    }
}
