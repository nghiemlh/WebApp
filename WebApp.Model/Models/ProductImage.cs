using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Model.Abstract;

namespace WebApp.Model.Models
{
	[Table("ProductImages")]
	public class ProductImage : Auditable
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int ProductId { get; set; }

		[StringLength(250)]
		public string Path { get; set; }

		[StringLength(250)]
		public string Caption { get; set; }

		[ForeignKey("ProductId")]
		public virtual Product Product { get; set; }
	}
}