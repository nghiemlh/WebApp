using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Model.Abstract;

namespace WebApp.Model.Models
{
	[Table("Pages")]
	public class Page : Auditable
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { set; get; }

		[Required]
		[MaxLength(256)]
		public string Name { set; get; }

		[Column(TypeName = "varchar")]
		[MaxLength(256)]
		[Required]
		public string Alias { set; get; }

		[MaxLength(500)]
		public string Description { set; get; }

		public string Content { set; get; }

		[MaxLength(256)]
		public string Image { set; get; }

	}
}