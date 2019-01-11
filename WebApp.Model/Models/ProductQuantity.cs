using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Model.Abstract;

namespace WebApp.Model.Models
{
	[Table("ProductQuantities")]
	public class ProductQuantity : Auditable
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int ProductId { get; set; }
		public int? SizeId { get; set; }
		public int? ColorId { get; set; }
		public int Quantity { get; set; }
		
		[ForeignKey("ProductId")]
		public virtual Product Product { get; set; }

		[ForeignKey("SizeId")]
		public virtual Size Size { get; set; }

		[ForeignKey("ColorId")]
		public virtual Color Color { get; set; }
	}
}