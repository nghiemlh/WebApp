﻿using System;
using System.Collections.Generic;

namespace WebApp.Web.Models
{
	public class AppUserViewModel
	{
		public string Id { set; get; }
		public string FullName { set; get; }
		public DateTime BirthDay { set; get; }
		public string Email { set; get; }
		public string Password { set; get; }
		public string UserName { set; get; }
		public string Address { get; set; }
		public string PhoneNumber { set; get; }
		public string Avatar { get; set; }
		public bool Status { get; set; }
		public string Gender { get; set; }

		public ICollection<string> Roles { get; set; }
	}
}