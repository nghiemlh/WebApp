using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Model.Abstract;

namespace WebApp.Model.Models
{
	[Table("Slides")]
	public class Slide : Auditable
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { set; get; }

		[Required]
		[MaxLength(256)]
		public string Name { set; get; }

		[MaxLength(256)]
		public string Description { set; get; }

		[MaxLength(256)]
		public string Image { set; get; }

		[MaxLength(256)]
		public string Url { set; get; }

		public int? DisplayOrder { set; get; }

		public string Content { set; get; }
	}
}