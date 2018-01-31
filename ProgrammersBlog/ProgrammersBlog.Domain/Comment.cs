using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammersBlog.Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Body { get; set; }
        public bool Deleted { get; set; }
		public DateTimeOffset CreatedDate { get; set; }
		public int UserId { get; set; }
		public int PostId { get; set; }
		public User User { get; set; }
		public Post Post { get; set; }
		public ICollection<Reply> Replies { get; set; }

		//public ICollection<CommentLike> CommentLikes { get; set; }
		public Comment()
		{
			Replies = new List<Reply>();
		}
	}
}