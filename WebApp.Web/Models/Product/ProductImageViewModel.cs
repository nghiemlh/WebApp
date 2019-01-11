using System;

namespace WebApp.Web.Models
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }
        public string Caption { get; set; }
		public DateTime? CreatedDate { set; get; }
		public string CreatedBy { set; get; }
		public DateTime? UpdatedDate { set; get; }
		public string UpdatedBy { set; get; }
		public bool Status { set; get; }

		public virtual ProductViewModel Product { get; set; }
	}
}