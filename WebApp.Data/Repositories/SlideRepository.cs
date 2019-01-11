using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface ISlideRepository : IRepository<Slide>
	{
	}

	public class SlideRepository : RepositoryBase<Slide>, ISlideRepository
	{
		public SlideRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}