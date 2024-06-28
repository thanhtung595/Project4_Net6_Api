using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Services.Jwt
{
    public interface IJwtService
    {
        Task<string> CreateJwt(int id_Account, string name_Role);
    }
}
