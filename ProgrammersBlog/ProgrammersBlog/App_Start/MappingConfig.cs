using AutoMapper;
using ProgrammersBlog;
using ProgrammersBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProgrammersBlog
{
	public class MappingConfig
	{
		public static void Configure()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<ProgrammersBlog.Domain.Post, PostModel>()
					.ForMember(view => view.User, dto => dto.MapFrom(t => t.User))
					.ForMember(view => view.Comments, dto => dto.MapFrom(t => t.Comments)).PreserveReferences().ReverseMap();

				cfg.CreateMap<ProgrammersBlog.Domain.Comment, CommentModel>()
					.ForMember(view => view.User, dto => dto.MapFrom(t => t.User))
					.ForMember(view => view.Post, dto => dto.MapFrom(t => t.Post))
					.ForMember(view => view.Replies, dto => dto.MapFrom(t => t.Replies)).PreserveReferences().ReverseMap();

				cfg.CreateMap<ProgrammersBlog.Domain.Reply, ReplyModel>()
					.ForMember(view => view.User, dto => dto.MapFrom(t => t.User))
					.ForMember(view => view.Comment, dto => dto.MapFrom(t => t.Comment))
					.ForMember(view => view.ParentReply, dto => dto.MapFrom(t => t.ParentReply))
					.ForMember(view => view.Replies, dto => dto.MapFrom(t => t.Replies)).PreserveReferences().ReverseMap();

				// used to convert all DateTimeOffset to configured Timezone
				cfg.CreateMap<ProgrammersBlog.Domain.Role, RoleItem>();

				cfg.CreateMap<UserModel, ProgrammersBlog.Domain.User>()
					.ForMember(x => x.Password, opt => opt.Ignore());

				cfg.CreateMap<ProgrammersBlog.Domain.User, UserModel>()
					.ForMember(view => view.UserName, dto => dto.MapFrom(t => t.UserName))
					.ForMember(view => view.Roles, dto => dto.MapFrom(t => t.Roles)).PreserveReferences().ReverseMap();


				//cfg.CreateMap<ReplyModel, ProgrammersBlog.Domain.Reply>()
					//.ForMember(x => x.CreatedDate, opt => opt.Ignore());
			});
		}

		
	}

	
}