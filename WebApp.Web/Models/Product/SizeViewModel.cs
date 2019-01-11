using System;

namespace WebApp.Web.Models
{
	public class SizeViewModel
	{
		public int Id { get; set; }
		public string Name { set; get; }
		public DateTime? CreatedDate { set; get; }
		public string CreatedBy { set; get; }
		public DateTime? UpdatedDate { set; get; }
		public string UpdatedBy { set; get; }
		public bool Status { set; get; }
	}
}