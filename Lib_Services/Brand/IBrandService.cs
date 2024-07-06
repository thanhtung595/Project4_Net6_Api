using Lib_Models.Model_Entities;
using Lib_Models.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Services.Brand
{
    public interface IBrandService
    {
        Task<List<BrandEntity>> GetAll();
        Task<StatusApplication> Add(string  name);  
    }
}
