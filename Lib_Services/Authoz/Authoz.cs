using BCrypt.Net;
using Lib_DatabaseEntity.Repository;
using Lib_Models.Model_Entities;
using Lib_Models.Model_Post;
using Lib_Models.Model_Table;
using Lib_Models.Status;
using Lib_Services.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Services.Authoz
{
    public class Authoz : IAuthoz
    {
        private readonly IRepository<AccountEntity> _accountRepository;
        private readonly IJwtService _jwtService;
        public Authoz(IRepository<AccountEntity> accountRepository, IJwtService jwtService)
        {
            _accountRepository = accountRepository;
            _jwtService = jwtService;
        }


        public async Task<StatusApplication> Login(LoginModel loginModel)
        {
            var account = await _accountRepository.GetAll(x => x.userName!.ToLower() == loginModel.username!.ToLower());

            if (!account.Any())
            {
                return new StatusApplication { isBool = false, message = "Tài khoản hoặc mật khẩu không đúng" };
            }

            var accountRl = account.First();

            var isHassPass = BCrypt.Net.BCrypt.Verify(loginModel.userpass, accountRl.userPass);
            if (!isHassPass)
            {
                return new StatusApplication { isBool = false, message = "Tài khoản hoặc mật khẩu không đúng" };
            }

            string isAdmin = "";
            if (accountRl.isAdmin)
            {
                isAdmin = "true";
            }
            else
            {
                isAdmin = "false";
            }

            string jwt = await _jwtService.CreateJwt(accountRl.id, isAdmin);

            return new StatusApplication
            {
                isBool = true,
                message = jwt,
                obj = new LoginModelTable
                {
                    userName = accountRl.userName,
                    email = accountRl.email,
                    fullName = accountRl.fullName,
                    isAdmin = accountRl.isAdmin,
                    isBan = accountRl.isBan,
                    phoneNumber = accountRl.phoneNumber
                }
            };
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<StatusApplication> Register(RegisterModel register)
        {
            var emailCheck = await _accountRepository.GetAll(x => x.userName!.ToLower() == register.userName!.ToLower()
                || x.email == register.email);

            if (emailCheck.Any())
            {
                if (emailCheck.First().userName!.ToLower() == register.userName!.ToLower())
                {
                    return new StatusApplication { isBool = false, message = "User name đã tồn tại" };
                }
                if (emailCheck.First().email!.ToLower() == register.email!.ToLower())
                {
                    return new StatusApplication { isBool = false, message = "Email đã tồn tại" };
                }
            }

            string hasPass = BCrypt.Net.BCrypt.HashPassword(register.userPass);

            AccountEntity account = new AccountEntity
            {
                userName = register.userName!.ToLower(),
                userPass = hasPass,
                fullName = "",
                phoneNumber = "",
                email = register.email!.ToLower(),
                isAdmin = false,
                isBan = false,
                timeCreate = DateTime.Now,
            };

            await _accountRepository.Insert(account);
            await _accountRepository.Commit();
            return new StatusApplication
            {
                isBool = true,
                message = "success"
            };
        }
    }
}
