using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Model.Abstract;

namespace WebApp.Model.Models
{
	[Table("OrderDetails")]
	public class OrderDetail : Auditable
	{
		[Key]
		[Column(Order = 1)]
		public int DisplayOrder { set; get; }

		[Key]
		[Column(Order = 2)]
		public int OrderId { set; get; }

		public int ProductId { set; get; }
		public int? ColorId { get; set; }
		public int? SizeId { get; set; }	
		public int Quantity { set; get; }
		public decimal Price { set; get; }
		public decimal Amount { set; get; }
		
		[ForeignKey("OrderId")]
		public virtual Order Order { set; get; }

		[ForeignKey("ProductId")]
		public virtual Product Product { set; get; }

		[ForeignKey("ColorId")]
		public virtual Color Color { set; get; }

		[ForeignKey("SizeId")]
		public virtual Size Size { set; get; }
	}
}