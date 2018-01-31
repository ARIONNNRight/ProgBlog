using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlogDomain
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Permissions> Permissions { get; set; }

        public Role()
        {
            Users = new List<User>();
            Permissions = new List<Permissions>();
        }

    }
}
