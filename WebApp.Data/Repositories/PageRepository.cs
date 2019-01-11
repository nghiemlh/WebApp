using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IPageRepository : IRepository<Page>
	{
	}

	public class PageRepository : RepositoryBase<Page>, IPageRepository
	{
		public PageRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}