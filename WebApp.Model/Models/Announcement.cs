﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Model.Models
{
	[Table("Announcements")]
	public class Announcement
	{
		public Announcement()
		{
			AnnouncementUsers = new List<AnnouncementUser>();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { set; get; }

		[StringLength(250)]
		[Required]
		public string Title { set; get; }

		public string Content { set; get; }
		public DateTime? CreatedDate { set; get; }
		public string CreatedBy { set; get; }
		public DateTime? UpdatedDate { set; get; }
		public string UpdatedBy { set; get; }
		[StringLength(128)]
		public string UserId { set; get; }

		[ForeignKey("UserId")]
		public virtual AppUser AppUser { get; set; }

		public bool Status { get; set; }

		public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
	}
}