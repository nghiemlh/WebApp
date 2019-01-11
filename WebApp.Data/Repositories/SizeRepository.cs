using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface ISizeRepository : IRepository<Size>
	{
	}

	public class SizeRepository : RepositoryBase<Size>, ISizeRepository
	{
		public SizeRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}