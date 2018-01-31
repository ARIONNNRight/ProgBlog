using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProgrammersBlog.Models;
using ProgrammersBlog.Persistence.EntityFramework;
using ProgrammersBlog.Domain;
using ProgrammersBlog.Persistence.EntityFramework.Interfaces;
using ProgrammersBlog.Persistence.EntityFramework.Repositories;

namespace ProgrammersBlog.Controllers
{
    public class PostsController : BaseController
    {
        private ProgrammersBlogContext db = new ProgrammersBlogContext();

		private IProgrammersBlogRepository repository;

		public PostsController()
		{
			repository = new ProgrammersBlogRepository(db);
		}

		// GET: Posts
		public ActionResult Index()
        {
            var posts = db.Posts.ToList();
            var postModels = new List<PostModel>();

            foreach (var p in posts)
            {
                var pm = AutoMapper.Mapper.Map<Post, PostModel>(p);
                postModels.Add(pm);
            }
            return View(postModels);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = db.Posts
				.Include(p => p.User)
				.Include(p => p.Comments)
				.Single(p => p.PostId == id);
		
            if (post == null)
            {
                return HttpNotFound();
            }
			
            var pm = AutoMapper.Mapper.Map<Post, PostModel>(post);           
            return View(pm);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Title,Body,Deleted")] PostModel postModel)
        {
            var post = AutoMapper.Mapper.Map<PostModel, Post>(postModel) as Post;
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,Title,Body,Deleted")] PostModel post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        /****Comment Actions*****/
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public PartialViewResult CreateComment(int postId, string commentBody, int userId = 1)
        {
            Post post = db.Posts.Include(p => p.Comments).Single(p =>p.PostId == postId);
            if (ModelState.IsValid)
            {
                post.Comments.Add(new Comment { PostId = postId, UserId = userId, Body = commentBody });
                db.SaveChanges();
            }
            PostModel postModel = AutoMapper.Mapper.Map<Post, PostModel>(post);
          //  return RedirectToAction("Details/"+ postId.ToString());

            return PartialView("_PostComments", postModel);
        }

		public List<ReplyModel> GetReplies(CommentModel commentModel)
		{
			Comment comment = AutoMapper.Mapper.Map<CommentModel, Comment>(commentModel);

			var replies = repository.GetParentReplies(comment);
			var repliesModel = new List<ReplyModel>();

			foreach (var reply in replies)
			{
				var replyModel = AutoMapper.Mapper.Map<Reply, ReplyModel>(reply);
				repliesModel.Add(replyModel);
			}
			return repliesModel;
		}

		public List<ReplyModel> GetChildReplies(ReplyModel replyModel)
		{
			Reply reply = AutoMapper.Mapper.Map<ReplyModel, Reply>(replyModel);

			var childReplies = repository.GetChildReplies(reply);
			var childRepliesModel = new List<ReplyModel>();

			foreach (var childReply in childReplies)
			{
				var childReplyModel = AutoMapper.Mapper.Map<Reply, ReplyModel>(childReply);
				childRepliesModel.Add(replyModel);
			}
			return childRepliesModel;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public PartialViewResult NewReply(int commentId, string replyBody)
		{
			//Getting the Comment
			Comment comment = repository.GetCommentById(commentId);
			//Creating new Reply to the Comment
			Reply newReply = new Reply() {	CommentId = commentId, Body = replyBody, UserId = 2, CreatedDate = DateTimeOffset.Now	};
			// Using NULL-Conditional Operator to check if the Comment is NOT null and adding new Reply to it
			comment?.Replies.Add(newReply);
			// Saving changes in Database
			repository.Save();

			return PartialView("_CommentReplies", ConverToModel<CommentModel>(comment));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public PartialViewResult NewReplyReply(int replyId, string replyBody)
		{
			//Getting the Comment
			
			//Creating new Reply to the Comment
			Reply newReply = new Reply() { ParentReplyId = replyId, Body = replyBody, UserId = 2, CreatedDate = DateTimeOffset.Now };
			repository.AddNewReply(newReply);
			// Saving changes in Database
			repository.Save();

			Reply parentReply = repository.GetReplyById(replyId);

			return PartialView("_ReplyReplies", ConverToModel<ReplyModel>(parentReply));
		}
	}
}
