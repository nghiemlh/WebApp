using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IProductTagRepository : IRepository<ProductTag>
	{
	}

	public class ProductTagRepository : RepositoryBase<ProductTag>, IProductTagRepository
	{
		public ProductTagRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}