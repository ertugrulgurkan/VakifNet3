using Catalog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Services
{
   public interface IUserService
    {
        User ValidateUser(string username, string password);
    }
}
