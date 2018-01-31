using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Models
{
	public class RoleItem
	{
		public int RoleId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Deteled { get; set; }
		public ICollection<UserItem> Users { get; set; }
		public ICollection<PermissionItem> Permissions { get; set; }
		public RoleItem()
		{
			Users = new List<UserItem>();
			Permissions = new List<PermissionItem>();
		}
	}
}
