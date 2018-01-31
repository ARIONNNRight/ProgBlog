using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Domain
{
	[Table("Permission")]
	public class Permission
	{
		[Key]
		public int PermissionId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Deleted { get; set; }
		public virtual ICollection<Role> Roles { get; set; }
		
		public Permission()
		{
			Roles = new List<Role>();
		}
	}
}
