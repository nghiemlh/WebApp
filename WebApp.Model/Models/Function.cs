using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Model.Models
{
	[Table("Functions")]
	public class Function
	{
		[Key]
		[StringLength(50)]
		[Column(TypeName = "varchar")]
		public string Id { set; get; }

		[Required]
		[MaxLength(50)]
		public string Name { set; get; }

		[Required]
		[MaxLength(256)]
		public string URL { set; get; }

		public int DisplayOrder { set; get; }

		[StringLength(50)]
		[Column(TypeName = "varchar")]
		public string ParentId { set; get; }

		[ForeignKey("ParentId")]
		public virtual Function Parent { set; get; }

		public bool Status { set; get; }
		public bool? IsLast { set; get; }

		[MaxLength(256)]
		public string IconCss { get; set; }
	}
}