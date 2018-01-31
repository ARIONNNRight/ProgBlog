using ProgrammersBlog.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProgrammersBlog.Domain
{
	public class Reply
	{
		public int ReplyId { get; set; }
		public string Body { get; set; }
		public bool Deleted { get; set; }
		//[Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTimeOffset CreatedDate { get; set; }
		public int? CommentId { get; set; }
		public int? ParentReplyId { get; set; }
		public int UserId { get; set; }

		public Comment Comment { get; set; }
		public Reply ParentReply { get; set; }
		public User User { get; set; }
		public ICollection<Reply> Replies { get; set; }

		public Reply()
		{
			Replies = new List<Reply>();
		}
	}
}