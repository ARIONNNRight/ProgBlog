using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammersBlog.Models
{
    public class PermissionsModel
    {
        public int PermissionsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

        public ICollection<RoleModel> Roles { get; set; }

        public PermissionsModel()
        {
           Roles = new List<RoleModel>();
        }
    }
}