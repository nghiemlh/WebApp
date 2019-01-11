using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IVisitorStatisticRepository : IRepository<VisitorStatistic>
	{
	}

	public class VisitorStatisticRepository : RepositoryBase<VisitorStatistic>, IVisitorStatisticRepository
	{
		public VisitorStatisticRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}