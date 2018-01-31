using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlogDomain
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public DateTime Birthday { get; set; }
        public string Avatar { get; set; }
        public string Password { get; set; }

        public ICollection<Role> Roles { get; set; }
        public User()
        {
            Roles = new List<Role>();
        }

    }
}
