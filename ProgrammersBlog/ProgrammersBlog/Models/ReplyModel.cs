using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgrammersBlog.Models
{
	public class ReplyModel
	{
		public int ReplyId { get; set; }
		[Required]
		public string Body { get; set; }
		[DefaultValue(false)]
		public bool Deleted { get; set; }
		public DateTimeOffset CreatedDate { get; set; }
		public int? CommentId { get; set; }
		public int? ParentReplyId { get; set; }
		public int UserId { get; set; }
		public CommentModel Comment { get; set; }
		public ReplyModel ParentReply { get; set; }
		public UserModel User { get; set; }

		//public ICollection<ReplyLike> ReplyLikes { get; set; }
		public ICollection<ReplyModel> Replies { get; set; }

		//public ICollection<CommentLike> CommentLikes { get; set; }

		public ReplyModel()
		{
			Replies = new List<ReplyModel>();
		}
	}
}