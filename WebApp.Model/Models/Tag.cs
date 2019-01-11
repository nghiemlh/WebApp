using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Model.Abstract;

namespace WebApp.Model.Models
{
	[Table("Tags")]
	public class Tag : Auditable
	{
		[Key]
		[MaxLength(50)]
		[Column(TypeName = "varchar")]
		public string Id { set; get; }

		[MaxLength(50)]
		[Required]
		public string Name { set; get; }

		[MaxLength(50)]
		[Required]
		public string Type { set; get; }
	}
}