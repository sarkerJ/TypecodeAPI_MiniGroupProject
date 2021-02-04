using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypecodeAPIService.DTOs;

namespace TypecodeAPIService.Utilities
{
    public static class UsersUtilities
    {
        public static int FindNumberOfUsers(UsersDTO[] users) => users.Count();

        public static bool VerifyUserExistsByName(UsersDTO[] users, string name) => users.Where(x => x.name == name).Count() > 0;

        public static UsersDTO GetUserIfExists(UsersDTO[] users, string name) => users.Where(x => x.name == name).FirstOrDefault();
    }
}
