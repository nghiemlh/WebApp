using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Model.Abstract
{
	public abstract class Auditable : IAuditable
	{
		public DateTime? CreatedDate { set; get; }

		[MaxLength(256)]
		public string CreatedBy { set; get; }

		public DateTime? UpdatedDate { set; get; }

		[MaxLength(256)]
		public string UpdatedBy { set; get; }

		public bool Status { set; get; }
	}
}