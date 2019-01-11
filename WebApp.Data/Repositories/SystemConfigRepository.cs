using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface ISystemConfigRepository : IRepository<SystemConfig>
	{
	}

	public class SystemConfigRepository : RepositoryBase<SystemConfig>, ISystemConfigRepository
	{
		public SystemConfigRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}