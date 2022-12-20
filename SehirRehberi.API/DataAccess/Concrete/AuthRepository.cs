using Microsoft.EntityFrameworkCore;
using SehirRehberi.API.DataAccess.Abrtract;
using SehirRehberi.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.DataAccess.Concrete
{
    public class AuthRepository : IAuthRepository
    {

        public async Task<User> Login(string userName, string password)
        {
            using (DataContext context = new DataContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
                if (user == null)
                {
                    return null;
                }
                if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                {
                    return null;
                }
                return user;
            }
        }

        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPasswordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public async Task<User> Register(User user, string password)
        {
            //Kayıt olma işleminde passworde salt eklenir,veri tabanına o şekilde kayıt edilir. 
            using (DataContext context = new DataContext())
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return user;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //salt
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); // girilen passwordün şifrelenmesi.
            }
        }

        public async Task<bool> UserExists(string userName)
        {
            using (DataContext context = new DataContext())
            {
                if (await context.Users.AnyAsync(x => x.UserName == userName))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
