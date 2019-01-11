using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IPostCategoryRepository : IRepository<PostCategory>
	{
	}

	public class PostCategoryRepository : RepositoryBase<PostCategory>, IPostCategoryRepository
	{
		public PostCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}