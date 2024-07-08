using Lib_Models.Model_Get;
using Lib_Models.Model_Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Services.Cart
{
    public interface ICartService
    {
        Task<List<CartGetAll>> GetAll();
        Task Add(CartAdd_Post cartAdd);
        Task Update(CartModel_Update cart);
        Task Delete(int id);
    }
}
