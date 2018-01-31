using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammersBlog.Models
{
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

        public ICollection<UserModel> Users { get; set; }
        public ICollection<PermissionsModel> Permissions { get; set; }

        public RoleModel()
        {
            Users = new List<UserModel>();
            Permissions = new List<PermissionsModel>();
        }

    }
}