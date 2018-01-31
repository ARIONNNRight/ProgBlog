using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Domain
{
	[Table("Role")]
	public class Role
	{
		[Key]
		public int RoleId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Deteled { get; set; }
		public virtual ICollection<User> Users { get; set; }
		public virtual ICollection<Permission> Permissions { get; set; }
		public Role()
		{
			Users = new List<User>();
			Permissions = new List<Permission>();
		}
	}
}
