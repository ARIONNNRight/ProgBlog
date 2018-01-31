using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammersBlog.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string Body { get; set; }
        public bool Deleted { get; set; }
		public DateTimeOffset CreatedDate { get; set; }
		public int PostId { get; set; }
		public int UserId { get; set; }
		public PostModel Post { get; set; }
		public UserModel User { get; set; }
		public ICollection<ReplyModel> Replies { get; set; }

		//public ICollection<CommentLike> CommentLikes { get; set; }

		public CommentModel()
		{
			Replies = new List<ReplyModel>();
		}
	}

}