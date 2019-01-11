using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IColorRepository : IRepository<Color>
	{
	}

	public class ColorRepository : RepositoryBase<Color>, IColorRepository
	{
		public ColorRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}