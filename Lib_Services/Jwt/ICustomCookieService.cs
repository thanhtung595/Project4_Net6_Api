using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Services.Jwt
{
    public interface ICustomCookieService
    {
        void DeleteCokie(string key);
        public void SetCookie(string domain, string key, string value, int expiresMinutes);
        void SetCookie(string domain, string key, object T, int expiresMinutes);
        void SetCookieAllTime(string domain, string key, string value);
    }
}
