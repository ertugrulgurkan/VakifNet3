using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entity
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserNAme { get; set; }
        public string Password { get; set; }
        public string MailAddress { get; set; }
    }
}
