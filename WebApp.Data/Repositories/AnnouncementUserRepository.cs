using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IAnnouncementUserRepository : IRepository<AnnouncementUser>
	{
	}

	public class AnnouncementUserRepository : RepositoryBase<AnnouncementUser>, IAnnouncementUserRepository
	{
		public AnnouncementUserRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}