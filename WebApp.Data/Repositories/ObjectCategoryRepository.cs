using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IObjectCategoryRepository : IRepository<ObjectCategory>
	{
	}

	public class ObjectCategoryRepository : RepositoryBase<ObjectCategory>, IObjectCategoryRepository
	{
		public ObjectCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}