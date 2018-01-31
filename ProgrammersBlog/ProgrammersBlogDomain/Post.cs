using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlogDomain
{
    public class Post
    {
        public int PostId { get; set; }
        //public int BlogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool Deleted { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Post()
        {
            Comments = new List<Comment>();
        }

    }

}
