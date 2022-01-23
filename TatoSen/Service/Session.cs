using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TatoSen.Service
{
    public class Session
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Session(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetString(string key)
        {
            return _httpContextAccessor.HttpContext.Session.GetString(key);
        }
    }
}
