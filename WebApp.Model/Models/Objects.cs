using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Model.Abstract;

namespace WebApp.Model.Models
{
	[Table("Objects")]
	public class Objects : Auditable
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { set; get; }

		[Required]
		[MaxLength(256)]
		public string Name { set; get; }

		[Required]
		[MaxLength(256)]
		public string Alias { set; get; }

		[Required]
		public int CategoryId { set; get; }

		[MaxLength(256)]
		public string Image { set; get; }

		[MaxLength(500)]
		public string Description { set; get; }

		public string Content { set; get; }

		[ForeignKey("CategoryId")]
		public virtual ObjectCategory ObjectCategory { set; get; }
	}
}