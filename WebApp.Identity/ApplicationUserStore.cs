using Microsoft.AspNet.Identity.EntityFramework;
using WebApp.Data;
using WebApp.Model.Models;

namespace WebApp.Identity
{
	public class ApplicationUserStore : UserStore<AppUser>
	{
		public ApplicationUserStore(WebAppDbContext context)
			: base(context)
		{
		}
	}
}