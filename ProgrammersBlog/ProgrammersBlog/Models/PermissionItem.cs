using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Models
{
	public class PermissionItem
	{ 
		public int PermissionId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Deleted { get; set; }
		[NotMapped]
		public virtual ICollection<RoleItem> Roles { get; set; }
		
		public PermissionItem()
		{
			Roles = new List<RoleItem>();
		}
	}
}
