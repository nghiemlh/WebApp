using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Model.Models
{
	[Table("Feedbacks")]
	public class Feedback
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { set; get; }

		[StringLength(250)]
		[Required]
		public string Name { set; get; }

		[StringLength(250)]
		public string Email { set; get; }

		[StringLength(500)]
		public string Message { set; get; }

		public DateTime CreatedDate { set; get; }

		public bool Status { set; get; }
	}
}