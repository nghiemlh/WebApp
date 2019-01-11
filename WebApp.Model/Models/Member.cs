using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Model.Abstract;

namespace WebApp.Model.Models
{
	[Table("Members")]
	public class Member : Auditable
	{
		[Key]
		[MaxLength(15)]
		[Column(TypeName = "varchar")]
		public string Id { set; get; }

		[Required]
		[MaxLength(256)]
		public string Name { set; get; }

		[MaxLength(256)]
		public string Image { set; get; }

		[MaxLength(50)]
		[Required]
		public string Type { set; get; }

		[Required]
		public int ObjectId { set; get; }

		[ForeignKey("ObjectId")]
		public virtual Objects Object { set; get; }
	}
}