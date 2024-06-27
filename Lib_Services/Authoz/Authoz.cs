using Lib_DatabaseEntity.Repository;
using Lib_Models.Model_Entities;
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
    public class Authoz : IAuthoz
    {
        private readonly IRepository<Account> _accountRepository;
        public Authoz(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }


        public async Task<LoginModelTable> Login(LoginModel loginModel)
        {
            var account = await _accountRepository.GetAll(x => x.userName!.ToLower() == loginModel.username!.ToLower()
            && x.userPass!.ToLower() == loginModel.userpass!.ToLower());

            if (!account.Any())
            {
                return new LoginModelTable { isBool = false, message = "Tài khoản hoặc mật khẩu không đúng" };
            }

            var accountRl = account.First();

            return new LoginModelTable
            {
                userName = accountRl.userName,
                email = accountRl.email,
                fullName = accountRl.fullName,
                isAdmin = accountRl.isAdmin,
                isBan = accountRl.isBan,
                isBool = true,
                message = "success",
                phoneNumber = accountRl.phoneNumber
            };
        }
    }
}
