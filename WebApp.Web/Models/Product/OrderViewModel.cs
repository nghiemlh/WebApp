using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApp.Model.Models;

namespace WebApp.Web.Models
{
	public class OrderViewModel
	{
		public int Id { set; get; }

		[Required]
		[MaxLength(50)]
		public string NumOrder { set; get; }

		[Required]
		[MaxLength(256)]
		public string CustomerName { set; get; }

		[MaxLength(512)]
		public string CustomerAddress { set; get; }

		[MaxLength(256)]
		public string CustomerEmail { set; get; }

		[MaxLength(50)]
		public string CustomerMobile { set; get; }

		[MaxLength(512)]
		public string CustomerMessage { set; get; }

		[MaxLength(256)]
		public string PaymentMethod { set; get; }
		public bool PaymentStatus { set; get; }

		public DateTime? CreatedDate { set; get; }
		public string CreatedBy { set; get; }
		public DateTime? UpdatedDate { set; get; }
		public string UpdatedBy { set; get; }
		public bool Status { set; get; }

		[MaxLength(128)]
		public string CustomerId { set; get; }
		public string BankCode { set; get; }

		public ICollection<OrderDetail> OrderDetails { set; get; }
	}
}