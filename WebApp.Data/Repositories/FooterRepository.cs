using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IFooterRepository : IRepository<Footer>
	{
	}

	public class FooterRepository : RepositoryBase<Footer>, IFooterRepository
	{
		public FooterRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}