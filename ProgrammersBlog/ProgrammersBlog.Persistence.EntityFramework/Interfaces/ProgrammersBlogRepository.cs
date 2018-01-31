using ProgrammersBlog.Domain;
using ProgrammersBlog.Persistence.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProgrammersBlog.Persistence.EntityFramework.Repositories
{
	public class ProgrammersBlogRepository: IProgrammersBlogRepository
	{
		private ProgrammersBlogContext _context;
		public ProgrammersBlogRepository(ProgrammersBlogContext context)
		{
			_context = context;
		}

		public Comment GetCommentById(int id)
		{
			return _context.Comments.Include(w => w.Replies).Single(c => c.CommentId == id);
		}

		public Reply GetReplyById(int id)
		{
			return _context.Replies.Include(r => r.Replies).Single(c => c.ReplyId == id);
		}
		

		public List<Reply> GetParentReplies(Comment comment)
		{
			var parentReplies = _context.Replies.Where(p => p.CommentId == comment.CommentId).ToList();
			List<Reply> parReplies = new List<Reply>();
			foreach (var pr in parentReplies)
			{
				var chReplies = GetChildReplies(pr);
				pr.Replies = chReplies;
				parReplies.Add(pr);
				//parReplies.Add(new Reply() { Body = pr.Body, ParentReplyId = pr.ParentReplyId, ReplyId = pr.ReplyId, UserId = pr.UserId, Replies = chReplies });
			}
			return parReplies;
		}

		public List<Reply> GetChildReplies(Reply parentReply)
		{
			List<Reply> chldReplies = new List<Reply>();
			if (parentReply != null)
			{
				var childReplies = _context.Replies.Where(p => p.ParentReplyId == parentReply.ReplyId).ToList();
				foreach (var reply in childReplies)
				{
					var chReplies = GetChildReplies(reply);
					reply.Replies = chReplies;
					chldReplies.Add(reply);
				}
			}
			return chldReplies;
		}
		public void AddNewReply(Reply reply)
		{
			_context.Replies.Add(reply);
			Save();
		}



		public void Save()
		{
			_context.SaveChanges();
		}


		// Implementation of the IDisposible Interface
		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
