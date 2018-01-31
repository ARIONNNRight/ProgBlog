using ProgrammersBlog.Common;
using ProgrammersBlog.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace ProgrammersBlog.Persistence.EntityFramework
{
	public class ProgrammersBlogContext : DbContext
    {
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<Permission> Permissions { get; set; }
		public virtual DbSet<Blog> Blogs { get; set; }
		public virtual DbSet<Post> Posts { get; set; }
		public virtual DbSet<Comment> Comments { get; set; }
		public virtual DbSet<Reply> Replies { get; set; }
		public ProgrammersBlogContext()
			: base(Constants.ProgrammersBlogConnectionStringName)
			{
				Database.SetInitializer<ProgrammersBlogContext>(null);

				this.Configuration.LazyLoadingEnabled = false;
				this.Configuration.ProxyCreationEnabled = false;
				this.Database.CommandTimeout = 120;
			}

			public ProgrammersBlogContext(DbConnection connection)
				: base(connection, true)
			{ }

		

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<Comment>()
			   .HasRequired<Post>(e => e.Post)
			   .WithMany(e => e.Comments)
			   .HasForeignKey(e => e.PostId);

			modelBuilder.Entity<Reply>()
			   .HasOptional<Comment>(e => e.Comment)
			   .WithMany(e => e.Replies)
			   .HasForeignKey(e => e.CommentId);

			modelBuilder.Entity<Reply>()
			   .HasOptional<Reply>(e => e.ParentReply)
			   .WithMany(e => e.Replies)
			   .HasForeignKey(e => e.ParentReplyId);

			modelBuilder.Entity<Role>()
				.HasMany<Permission>(role => role.Permissions)
				.WithMany(permission => permission.Roles)
				.Map(rolePermission =>
				{
					rolePermission.MapLeftKey("RoleId");
					rolePermission.MapRightKey("PermissionId");
					rolePermission.ToTable("Role_Permission");
				});

			modelBuilder.Entity<User>()
				.HasMany<Role>(user => user.Roles)
				.WithMany(role => role.Users)
				.Map(userRole =>
				{
					userRole.MapLeftKey("UserId");
					userRole.MapRightKey("RoleId");
					userRole.ToTable("User_Role");
				});

			
		}

		}
	}
