using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProgrammersBlog.Domain;
using ProgrammersBlog.Persistence.EntityFramework;
using ProgrammersBlog.Models;
using AutoMapper;

namespace ProgrammersBlog.Controllers
{
    public class AdminController : Controller
    {
        private ProgrammersBlogContext db = new ProgrammersBlogContext();



        // GET: Users
        public ActionResult Index()
        {
			var userList = db.Users.ToList();
			var users = new List<UserItem>();
			if (userList.Any())
			{
				foreach (var user in userList)
				{
					ProgrammersBlog.Models.UserItem userModel = Mapper.Map<Domain.User, Models.UserItem>(user);
					users.Add(userModel);
				}
			}
			return View(users);



			//return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			// User user = db.Users.Find(id);
			User user = db.Users.Include(usr => usr.Roles).Single<User>(item => item.UserId == id);

			if (user == null)
            {
                return HttpNotFound();
            }

			ProgrammersBlog.Models.UserItem userModel = Mapper.Map<Domain.User, Models.UserItem>(user);

			return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Email,Password,BirthDay,Avatar")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //User user = db.Users.Find(id);
			User user = db.Users.Include(usr => usr.Roles).Single<User>(item => item.UserId == id);
			if (user == null)
            {
                return HttpNotFound();
            }
			SetViewBagData(user);
			UserItem userModel = Mapper.Map<Domain.User, Models.UserItem>(user);
			return View(userModel);
	}

		private List<RoleItem> GetAvailableRolesForUser(User user)
		{
			List<RoleItem> result = new List<RoleItem>();
			try
			{
				var roles = db.Roles.OrderBy(r => r.Name).ToList();
				var availableRoles = roles.Where(r => user.Roles.All(userRole => userRole.RoleId != r.RoleId));
				foreach (var role in availableRoles)
				{
					RoleItem roleItem = Mapper.Map<Domain.Role, Models.RoleItem>(role);
					result.Add(roleItem);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return result;
		}

		private void SetViewBagData(User user)
		{
			ViewBag.UserId = user.UserId;
			//ViewBag.List_boolNullYesNo = this.List_boolNullYesNo();

			var availableRoles = GetAvailableRolesForUser(user);
			ViewBag.Roles = new SelectList(availableRoles, "RoleId", "Name");
		}



		[HttpGet]
		[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
		public PartialViewResult DeleteUserRoleReturnPartialView(int userId, int roleId)
		{
			User user = db.Users.Include(usr => usr.Roles).Single<User>(item => item.UserId == userId);
			if (user.Roles.Where(p => p.RoleId == roleId).Count() > 0)
			{
				user.Roles.Remove(user.Roles.Where(p => p.RoleId == roleId).FirstOrDefault());
				//user.LastModified = DateTime.Now;
				db.Entry(user).State = EntityState.Modified;
				db.SaveChanges();

				//ApplicationUserManager.RemoveUser4Role(userId, id);

				//SetViewBagData(userId);
				
			}
			SetViewBagData(user);
			UserItem userModel = Mapper.Map<Domain.User, Models.UserItem>(user);
			return PartialView("_ListUserRoleTable", userModel);
		}

		[HttpGet]
		[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
		public PartialViewResult AddUserRoleReturnPartialView(int userId, int roleId)
		{


			//ApplicationUserManager.AddUser2Role(userId, id);

			//SetViewBagData(userId);

			User user = db.Users.Include(usr => usr.Roles).Single<User>(item => item.UserId == userId);
			Role role = db.Roles.Single<Role>(item => item.RoleId == roleId);
			//var role = new Role { Name = "System Admin" };
			user.Roles.Add(role);

			//Now add this book, with all its relationships, to the database
			db.SaveChanges();
			UserModel userModel = Mapper.Map<Domain.User, Models.UserModel>(user);
			//return PartialView("_ListUserRoleTable", ApplicationUserManager.GetUser(userId));
			return PartialView("_ListUserRoleTable", userModel);

		}


		// POST: Users/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Email,Password,BirthDay,Avatar")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;

				var role = new Role { Name = "System Admin" };
				user.Roles.Add(role);

				//Now add this book, with all its relationships, to the database
				db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
    }
}
