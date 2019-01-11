using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IOrderDetailRepository : IRepository<OrderDetail>
	{
	}

	public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
	{
		public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}