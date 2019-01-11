using System;

namespace WebApp.Web.Models
{
	public class ProductQuantityViewModel
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int? SizeId { get; set; }
		public int? ColorId { get; set; }
		public int Quantity { get; set; }
		public DateTime? CreatedDate { set; get; }
		public string CreatedBy { set; get; }
		public DateTime? UpdatedDate { set; get; }
		public string UpdatedBy { set; get; }
		public bool Status { set; get; }


		public virtual ProductViewModel Product { get; set; }
		public virtual SizeViewModel Size { get; set; }
		public virtual ColorViewModel Color { get; set; }
	}
}