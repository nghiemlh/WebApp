using System.Collections.Generic;
using System.Linq;
using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IProductQuantityRepository : IRepository<ProductQuantity>
	{
	}

	public class ProductQuantityRepository : RepositoryBase<ProductQuantity>, IProductQuantityRepository
	{
		public ProductQuantityRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}