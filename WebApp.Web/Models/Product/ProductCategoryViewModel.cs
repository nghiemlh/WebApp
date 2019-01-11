﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Yêu cầu nhập tên danh mục")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Yêu cầu nhập tiêu đề SEO")]
        public string Alias { set; get; }
        public string Description { set; get; }
        public int? ParentId { set; get; }
        public int? DisplayOrder { set; get; }
        public string Image { set; get; }
        public bool? HomeFlag { set; get; }
		public bool? IsLast { set; get; }
		public int HomeOrder { get; set; }
        public DateTime? CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public DateTime? UpdatedDate { set; get; }
        public string UpdatedBy { set; get; }
        [Required(ErrorMessage = "Yêu cầu nhập trạng thái")]
        public bool Status { set; get; }

		public virtual IEnumerable<PostViewModel> Posts { set; get; }
	}
}