using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IMemberRepository : IRepository<Member>
	{
	}

	public class MemberRepository : RepositoryBase<Member>, IMemberRepository
	{
		public MemberRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}
