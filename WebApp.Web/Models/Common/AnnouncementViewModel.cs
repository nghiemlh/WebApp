using System;
using System.Collections.Generic;

namespace WebApp.Web.Models.Common
{
	public class AnnouncementViewModel
	{
		public AnnouncementViewModel()
		{
			AnnouncementUsers = new List<AnnouncementUserViewModel>();
		}

		public int Id { set; get; }

		public string Title { set; get; }

		public string Content { set; get; }
		public DateTime? CreatedDate { set; get; }
		public string CreatedBy { set; get; }
		public DateTime? UpdatedDate { set; get; }
		public string UpdatedBy { set; get; }
		public string UserId { set; get; }

		public AppUserViewModel AppUser { get; set; }

		public bool Status { get; set; }

		public virtual ICollection<AnnouncementUserViewModel> AnnouncementUsers { get; set; }
	}
}