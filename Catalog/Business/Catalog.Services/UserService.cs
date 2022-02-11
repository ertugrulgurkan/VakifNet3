using Catalog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Services
{
    public class UserService : IUserService
    {
        public User ValidateUser(string username, string password)
        {
            if (username=="turkay" && password =="123")
            {
                return new User { UserNAme = "turkay", MailAddress = "turkay.urkmez@dinamikzihin.com", Id = 1 };
            }
            return null;
        }
    }
}
