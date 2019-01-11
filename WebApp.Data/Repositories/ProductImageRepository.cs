using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IProductImageRepository : IRepository<ProductImage>
	{
	}

	public class ProductImageRepository : RepositoryBase<ProductImage>, IProductImageRepository
	{
		public ProductImageRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}