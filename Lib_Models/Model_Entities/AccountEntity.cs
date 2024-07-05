using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Entities
{
    public class AccountEntity : BaseEntity
    {
        public string? userName { get; set; }
        public string? userPass { get; set; }
        public string? fullName { get; set; }
        public string? phoneNumber { get; set; }
        public string? email { get; set; }
        public bool isBan { get; set; }
        public bool isAdmin { get; set; }
    }
}
