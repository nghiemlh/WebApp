﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Model.Abstract;

namespace WebApp.Model.Models
{
	[Table("ContactDetails")]
	public class ContactDetail : Auditable
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { set; get; }

		[StringLength(250)]
		[Required]
		public string Name { set; get; }

		[StringLength(50)]
		public string Phone { set; get; }

		[StringLength(250)]
		public string Email { set; get; }

		[StringLength(250)]
		public string Website { set; get; }

		[StringLength(250)]
		public string Address { set; get; }

		public string Other { set; get; }

		public double? Lat { set; get; }

		public double? Lng { set; get; }

		public bool Status { set; get; }
	}
}