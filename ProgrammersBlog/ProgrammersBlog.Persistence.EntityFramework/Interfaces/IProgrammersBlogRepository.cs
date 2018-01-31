using ProgrammersBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Persistence.EntityFramework.Interfaces
{
	public interface IProgrammersBlogRepository : IDisposable
	{
		//List<Comment> GetPostComments(Post post);

		Comment GetCommentById(int id);
		Reply GetReplyById(int id);
		List<Reply> GetParentReplies(Comment comment);
		List<Reply> GetChildReplies(Reply parentReply);

		void AddNewReply(Reply reply);
		void Save();
	}
}
