using Lib_Models.Model_Entities;
using Lib_Models.Model_Get;
using Lib_Models.Model_Post;
using Lib_Models.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Services.Product
{
    public interface IProductService
    {
        Task<List<ProductModel_Get>> GetAll();
        Task<StatusApplication> Add(ProductPost product);
        Task<StatusApplication> Update(ProductMode_Update product);
    }
}
