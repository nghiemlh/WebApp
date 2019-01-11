using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface ISupportOnlineRepository : IRepository<SupportOnline>
	{
	}

	public class SupportOnlineRepository : RepositoryBase<SupportOnline>, ISupportOnlineRepository
	{
		public SupportOnlineRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}