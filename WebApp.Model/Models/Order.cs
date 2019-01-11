using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Model.Abstract;

namespace WebApp.Model.Models
{
	[Table("Orders")]
	public class Order : Auditable
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

		[StringLength(128)]
		[Column(TypeName = "nvarchar")]
		public string CustomerId { set; get; }

		[ForeignKey("CustomerId")]
		public virtual AppUser User { set; get; }

		public virtual ICollection<OrderDetail> OrderDetails { set; get; }
	}
}