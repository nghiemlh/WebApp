using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IMenuRepository : IRepository<Function>
	{
	}

	public class MenuRepository : RepositoryBase<Function>, IMenuRepository
	{
		public MenuRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}