﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Model.Abstract;

namespace WebApp.Model.Models
{
	[Table("PostCategories")]
	public class PostCategory : Auditable
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { set; get; }

		[Required]
		[MaxLength(256)]
		public string Name { set; get; }

		[Required]
		[Column(TypeName = "varchar")]
		[MaxLength(256)]
		public string Alias { set; get; }

		[MaxLength(500)]
		public string Description { set; get; }

		public int? ParentId { set; get; }
		public int? DisplayOrder { set; get; }

		[MaxLength(256)]
		public string Image { set; get; }

		public bool? HomeFlag { set; get; }
		public bool? IsLast { set; get; }

		public virtual IEnumerable<Post> Posts { set; get; }
	}
}