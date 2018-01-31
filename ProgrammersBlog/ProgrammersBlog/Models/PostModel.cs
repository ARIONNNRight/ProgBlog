using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammersBlog.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        //public int BlogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool Deleted { get; set; }
		public DateTimeOffset CreatedDate { get; set; }
		public int UserId { get; set; }
		public UserModel User { get; set; }
		public ICollection<CommentModel> Comments{ get; set; }
        public PostModel()
        {
            Comments = new List<CommentModel>();
        }

    }
}