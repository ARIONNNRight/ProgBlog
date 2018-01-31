using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Domain
{
	[Table("User")]
	public class User
	{
		[Key]
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTimeOffset BirthDay { get; set; }
		public string Avatar { get; set; }
		public bool? Inactive { get; set; }

		public virtual ICollection<Role> Roles { get; set; }
		public User()
		{
			Roles = new List<Role>();
		}
	}
}
