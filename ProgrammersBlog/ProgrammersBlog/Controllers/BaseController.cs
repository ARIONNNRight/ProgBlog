using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammersBlog.Controllers
{
	public class BaseController: Controller
	{
		protected T ConverToModel<T>(object obj)
		{
			return AutoMapper.Mapper.Map<object, T>(obj);
		}
	}
}