using System;

namespace WebApp.Web.Models
{
    public class PageViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
		public string Description { set; get; }
		public string Content { set; get; }
		public string Image { set; get; }
		public DateTime? CreatedDate { set; get; }
		public string CreatedBy { set; get; }
		public DateTime? UpdatedDate { set; get; }
		public string UpdatedBy { set; get; }
		public bool Status { set; get; }
    }
}