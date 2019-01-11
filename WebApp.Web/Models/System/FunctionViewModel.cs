using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.Models
{
	public class FunctionViewModel
	{
		public string Id { set; get; }
		[Required]
		[MaxLength(50)]
		public string Name { set; get; }
		[Required]
		[MaxLength(256)]
		public string URL { set; get; }
		public int DisplayOrder { set; get; }
		[MaxLength(50)]
		public string ParentId { set; get; }
		public bool Status { set; get; }
		public string IconCss { get; set; }
		public bool? IsLast { set; get; }

		public ICollection<FunctionViewModel> ChildFunctions { set; get; }
	}
}