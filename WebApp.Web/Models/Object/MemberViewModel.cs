using System;

namespace WebApp.Web.Models
{
	public class MemberViewModel
	{
		public string Id { set; get; }
		public string Name { set; get; }
		public string Image { set; get; }
		public string Type { set; get; }
		public int ObjectId { set; get; }
		public DateTime? CreatedDate { set; get; }
		public string CreatedBy { set; get; }
		public DateTime? UpdatedDate { set; get; }
		public string UpdatedBy { set; get; }
		public bool Status { set; get; }
	}
}