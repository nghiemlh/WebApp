using WebApp.Model.Models;
using WebApp.Data.Infrastructure;

namespace WebApp.Data.Repositories
{
	public interface IObjectRepository : IRepository<Objects>
	{
	}

	public class ObjectRepository : RepositoryBase<Objects>, IObjectRepository
	{
		public ObjectRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}