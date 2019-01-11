using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.Models
{
	public class ColorViewModel
	{
		public int Id { get; set; }
		public string Name { set; get; }
		public string Code { get; set; }
		public DateTime? CreatedDate { set; get; }
		public string CreatedBy { set; get; }
		public DateTime? UpdatedDate { set; get; }
		public string UpdatedBy { set; get; }
		[Required(ErrorMessage = "Yêu cầu nhập trạng thái")]
		public bool Status { set; get; }
	}
}