using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IErrorRepository : IRepository<Error>
	{
	}

	public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
	{
		public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}