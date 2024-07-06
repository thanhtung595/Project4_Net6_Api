using Lib_Models.Model_Post;
using Lib_Models.Model_Table;
using Lib_Models.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Services.Authoz
{
    public interface IAuthoz
    {
        Task<StatusApplication> Login (LoginModel loginModel);
        Task<StatusApplication> Register(RegisterModel register);
    }
}
