using ProgrammersBlogDomain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProgrammersBlog.Models
{
    public class ProgrammersBlogContext: DbContext
    {
        public ProgrammersBlogContext() : base("ProgrammersBlogContext") { }

        public virtual DbSet <User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
      //  public virtual DbSet<UsersRoles> UsersRoless { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database.SetInitializer<ProgrammersBlogContext>(null);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Roles)
            //    .WithMany(e => e.Users)
            //    .Map(m => m.ToTable("UsersRoles")
            //    .MapLeftKey("UserId")
            //    .MapLeftKey("RoleId"));

            modelBuilder.Entity<Comment>()
               .HasRequired<Post>(e => e.Post)
               .WithMany(e => e.Comments)
               .HasForeignKey(e => e.PostId);

            //modelBuilder.Entity<Role>()
            // .HasRequired<User>(e => e.User)
            // .WithMany(e => e.Roles);

            modelBuilder.Entity<Permissions>()
               .HasMany(e => e.Roles)
               .WithMany(e => e.Permissions)
               .Map(m => m.ToTable("RolesPermissions")
               .MapLeftKey("PermissionId")
               .MapRightKey("RoleId"));

        }
       
    }
}