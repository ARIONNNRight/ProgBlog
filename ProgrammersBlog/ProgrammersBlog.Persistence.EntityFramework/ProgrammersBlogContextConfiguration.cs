using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Persistence.EntityFramework
{
	public  class ProgrammersBlogContextConfiguration : DbConfiguration
	{
			public ProgrammersBlogContextConfiguration()
			{
				SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
			}
	}
}
