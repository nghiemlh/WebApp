using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.Models
{
    public class OrderDetailViewModel
	{
		public int DisplayOrder { set; get; }
		public int OrderId { set; get; }
        public int ProductId { set; get; }
		public int? ColorId { get; set; }
		public int? SizeId { get; set; }
		public int Quantity { set; get; }
        public decimal Price { set; get; }
		public decimal Amount { set; get; }

		public DateTime? CreatedDate { set; get; }
		public string CreatedBy { set; get; }
		public DateTime? UpdatedDate { set; get; }
		public string UpdatedBy { set; get; }
		public bool Status { set; get; }

		public ProductViewModel Product { get; set; }
        public ColorViewModel Color { get; set; }
        public SizeViewModel Size { get; set; }
    }
}