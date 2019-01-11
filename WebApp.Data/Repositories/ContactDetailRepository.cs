using WebApp.Data.Infrastructure;
using WebApp.Model.Models;

namespace WebApp.Data.Repositories
{
	public interface IContactDetailRepository : IRepository<ContactDetail>
	{
	}

	public class ContactDetailRepository : RepositoryBase<ContactDetail>, IContactDetailRepository
	{
		public ContactDetailRepository(IDbFactory dbFactory) : base(dbFactory)
		{
		}
	}
}