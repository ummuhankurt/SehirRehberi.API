using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Helpers
{
    public static class JwtExtension
    {
        public static void AddApplicationError(this HttpResponse response,string message)
        {
            response.Headers.Add("Application error", message); //Kullanıcının göreceği mesaj : Application Error
            response.Headers.Add("Access-Control-Allow-Origin", "*"); //Cors sıkıntısı yaşanmaması için;bütün herkes istek atabilir anlamında.
            response.Headers.Add("Access-Control-Expose-Header", "Application-Error");

        }
    }
}
