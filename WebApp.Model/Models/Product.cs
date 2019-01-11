using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Model.Abstract;

namespace WebApp.Model.Models
{
	[Table("Products")]
	public class Product : Auditable
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
		public string ThumbnailImage { set; get; }

		[MaxLength(256)]
		public string IconCss { get; set; }

		public decimal Price { set; get; }

		public decimal OriginalPrice { set; get; }

		public decimal? PromotionPrice { set; get; }

		public bool IncludedVAT { get; set; }

		public int? Warranty { set; get; }

		[MaxLength(500)]
		public string Description { set; get; }

		public string Content { set; get; }

		public bool? HomeFlag { set; get; }

		public bool? HotFlag { set; get; }

		public int? ViewCount { set; get; }

		[MaxLength(256)]
		public string MetaKeyword { set; get; }

		[MaxLength(256)]
		public string MetaDescription { set; get; }

		public string Tags { set; get; }

		[ForeignKey("CategoryId")]
		public virtual ProductCategory ProductCategory { set; get; }

		public virtual ICollection<ProductTag> ProductTags { set; get; }
	}
}