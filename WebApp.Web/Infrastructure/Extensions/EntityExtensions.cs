using System;
using WebApp.Model.Models;
using WebApp.Web.Models;

namespace WebApp.Web.Infrastructure.Extensions
{
	public static class EntityExtensions
	{
		public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
		{
			postCategory.Id = postCategoryVm.Id;
			postCategory.Name = postCategoryVm.Name;
			postCategory.Description = postCategoryVm.Description;
			postCategory.Alias = postCategoryVm.Alias;
			postCategory.ParentId = postCategoryVm.ParentId;
			postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
			postCategory.Image = postCategoryVm.Image;
			postCategory.HomeFlag = postCategoryVm.HomeFlag;
			postCategory.IsLast = postCategoryVm.IsLast;

			postCategory.CreatedDate = postCategoryVm.CreatedDate;
			postCategory.CreatedBy = postCategoryVm.CreatedBy;
			postCategory.UpdatedDate = postCategoryVm.UpdatedDate;
			postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
			postCategory.Status = postCategoryVm.Status;
		}

		public static void UpdatePost(this Post post, PostViewModel postVm)
		{
			post.Id = postVm.Id;
			post.Name = postVm.Name;
			post.Description = postVm.Description;
			post.Alias = postVm.Alias;
			post.CategoryId = postVm.CategoryId;
			post.Content = postVm.Content;
			post.Image = postVm.Image;
			post.HomeFlag = postVm.HomeFlag;
			post.ViewCount = postVm.ViewCount;

			post.CreatedDate = postVm.CreatedDate;
			post.CreatedBy = postVm.CreatedBy;
			post.UpdatedDate = postVm.UpdatedDate;
			post.UpdatedBy = postVm.UpdatedBy;
			post.MetaKeyword = postVm.MetaKeyword;
			post.MetaDescription = postVm.MetaDescription;
			post.Status = postVm.Status;
		}

		public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVm)
		{
			productCategory.Id = productCategoryVm.Id;
			productCategory.Name = productCategoryVm.Name;
			productCategory.Description = productCategoryVm.Description;
			productCategory.Alias = productCategoryVm.Alias;
			productCategory.ParentId = productCategoryVm.ParentId;
			productCategory.DisplayOrder = productCategoryVm.DisplayOrder;
			productCategory.HomeOrder = productCategoryVm.HomeOrder;
			productCategory.Image = productCategoryVm.Image;
			productCategory.HomeFlag = productCategoryVm.HomeFlag;
			productCategory.HomeOrder = productCategoryVm.HomeOrder;
			productCategory.IsLast = productCategoryVm.IsLast;

			productCategory.CreatedDate = productCategoryVm.CreatedDate;
			productCategory.CreatedBy = productCategoryVm.CreatedBy;
			productCategory.UpdatedDate = productCategoryVm.UpdatedDate;
			productCategory.UpdatedBy = productCategoryVm.UpdatedBy;
			productCategory.Status = productCategoryVm.Status;
		}

		public static void UpdateProduct(this Product product, ProductViewModel productVm)
		{
			product.Id = productVm.Id;
			product.Name = productVm.Name;
			product.Description = productVm.Description;
			product.Alias = productVm.Alias;
			product.CategoryId = productVm.CategoryId;
			product.Content = productVm.Content;
			product.ThumbnailImage = productVm.ThumbnailImage;
			product.IconCss = productVm.IconCss;
			product.Price = productVm.Price;
			product.PromotionPrice = productVm.PromotionPrice;
			product.OriginalPrice = productVm.OriginalPrice;
			product.Warranty = productVm.Warranty;
			product.HomeFlag = productVm.HomeFlag;
			product.HotFlag = productVm.HotFlag;
			product.ViewCount = productVm.ViewCount;
			product.MetaKeyword = productVm.MetaKeyword;
			product.MetaDescription = productVm.MetaDescription;
			product.Tags = productVm.Tags;

			product.CreatedDate = productVm.CreatedDate;
			product.CreatedBy = productVm.CreatedBy;
			product.UpdatedDate = productVm.UpdatedDate;
			product.UpdatedBy = productVm.UpdatedBy;
			product.Status = productVm.Status;
		}

		public static void UpdateProductQuantity(this ProductQuantity quantity, ProductQuantityViewModel quantityVm)
		{
			quantity.ColorId = quantityVm.ColorId;
			quantity.ProductId = quantityVm.ProductId;
			quantity.SizeId = quantityVm.SizeId;
			quantity.Quantity = quantityVm.Quantity;

			quantity.CreatedDate = quantityVm.CreatedDate;
			quantity.CreatedBy = quantityVm.CreatedBy;
			quantity.UpdatedDate = quantityVm.UpdatedDate;
			quantity.UpdatedBy = quantityVm.UpdatedBy;
			quantity.Status = quantityVm.Status;
		}

		public static void UpdateProductImage(this ProductImage image, ProductImageViewModel imageVm)
		{
			image.ProductId = imageVm.ProductId;
			image.Path = imageVm.Path;
			image.Caption = imageVm.Caption;

			image.CreatedDate = imageVm.CreatedDate;
			image.CreatedBy = imageVm.CreatedBy;
			image.UpdatedDate = imageVm.UpdatedDate;
			image.UpdatedBy = imageVm.UpdatedBy;
			image.Status = imageVm.Status;
		}

		public static void UpdateOrder(this Order order, OrderViewModel orderVm)
		{
			order.NumOrder = orderVm.NumOrder;
			order.CustomerId = orderVm.CustomerId;
			order.CustomerName = orderVm.CustomerName;
			order.CustomerAddress = orderVm.CustomerAddress;
			order.CustomerEmail = orderVm.CustomerEmail;
			order.CustomerMobile = orderVm.CustomerMobile;
			order.CustomerMessage = orderVm.CustomerMessage;
			order.PaymentMethod = orderVm.PaymentMethod;
			order.PaymentStatus = orderVm.PaymentStatus;

			order.CreatedDate = orderVm.CreatedDate;
			order.CreatedBy = orderVm.CreatedBy;
			order.UpdatedDate = orderVm.UpdatedDate;
			order.UpdatedBy = orderVm.UpdatedBy;
			order.Status = orderVm.Status;
		}

		public static void UpdateObjectCategory(this ObjectCategory objectCategory, ObjectCategoryViewModel objectCategoryVm)
		{
			objectCategory.Id = objectCategoryVm.Id;
			objectCategory.Name = objectCategoryVm.Name;
			objectCategory.Description = objectCategoryVm.Description;
			objectCategory.Alias = objectCategoryVm.Alias;
			objectCategory.ParentId = objectCategoryVm.ParentId;
			objectCategory.DisplayOrder = objectCategoryVm.DisplayOrder;
			objectCategory.IsLast = objectCategoryVm.IsLast;
			objectCategory.Image = objectCategoryVm.Image;

			objectCategory.CreatedDate = objectCategoryVm.CreatedDate;
			objectCategory.CreatedBy = objectCategoryVm.CreatedBy;
			objectCategory.UpdatedDate = objectCategoryVm.UpdatedDate;
			objectCategory.UpdatedBy = objectCategoryVm.UpdatedBy;
			objectCategory.Status = objectCategoryVm.Status;
		}

		public static void UpdateObject(this Objects objects, ObjectViewModel objectVm)
		{
			objects.Id = objectVm.Id;
			objects.Name = objectVm.Name;
			objects.Description = objectVm.Description;
			objects.Alias = objectVm.Alias;
			objects.CategoryId = objectVm.CategoryId;
			objects.Content = objectVm.Content;
			objects.Image = objectVm.Image;

			objects.CreatedDate = objectVm.CreatedDate;
			objects.CreatedBy = objectVm.CreatedBy;
			objects.UpdatedDate = objectVm.UpdatedDate;
			objects.UpdatedBy = objectVm.UpdatedBy;
			objects.Status = objectVm.Status;
		}

		public static void UpdateFunction(this Function function, FunctionViewModel functionVm)
		{
			function.Id = functionVm.Id;
			function.Name = functionVm.Name;
			function.URL = functionVm.URL;
			function.DisplayOrder = functionVm.DisplayOrder;
			function.IconCss = functionVm.IconCss;
			function.Status = functionVm.Status;
			function.ParentId = functionVm.ParentId;
			function.Status = functionVm.Status;
			function.IsLast = functionVm.IsLast;
		}

		public static void UpdatePage(this Page page, PageViewModel pageVm)
		{
			page.Id = pageVm.Id;
			page.Name = pageVm.Name;
			page.Alias = pageVm.Alias;
			page.Description = pageVm.Description;
			page.Content = pageVm.Content;
			page.Image = pageVm.Image;
			page.CreatedDate = pageVm.CreatedDate;
			page.CreatedBy = pageVm.CreatedBy;
			page.UpdatedDate = pageVm.UpdatedDate;
			page.UpdatedBy = pageVm.UpdatedBy;
			page.Status = pageVm.Status;
		}

		public static void UpdateColor(this Color color, ColorViewModel colorVm)
		{
			color.Id = colorVm.Id;
			color.Name = colorVm.Name;			
			color.Code = colorVm.Code;
			color.CreatedDate = colorVm.CreatedDate;
			color.CreatedBy = colorVm.CreatedBy;
			color.UpdatedDate = colorVm.UpdatedDate;
			color.UpdatedBy = colorVm.UpdatedBy;
			color.Status = colorVm.Status;
		}

		public static void UpdateSize(this Size size, SizeViewModel sizeVm)
		{
			size.Id = sizeVm.Id;
			size.Name = sizeVm.Name;
			size.CreatedDate = sizeVm.CreatedDate;
			size.CreatedBy = sizeVm.CreatedBy;
			size.UpdatedDate = sizeVm.UpdatedDate;
			size.UpdatedBy = sizeVm.UpdatedBy;
			size.Status = sizeVm.Status;
		}

		public static void UpdateSlide(this Slide slide, SlideViewModel slideVm)
		{
			slide.Id = slideVm.Id;
			slide.Name = slideVm.Name;
			slide.Description = slideVm.Description;
			slide.Image = slideVm.Image;
			slide.Url = slideVm.Url;
			slide.DisplayOrder = slideVm.DisplayOrder;
			slide.Content = slideVm.Content;

			slide.CreatedDate = slideVm.CreatedDate;
			slide.CreatedBy = slideVm.CreatedBy;
			slide.UpdatedDate = slideVm.UpdatedDate;
			slide.UpdatedBy = slideVm.UpdatedBy;
			slide.Status = slideVm.Status;
		}

		public static void UpdateFeedback(this Feedback feedback, FeedbackViewModel feedbackVm)
		{
			feedback.Name = feedbackVm.Name;
			feedback.Email = feedbackVm.Email;
			feedback.Message = feedbackVm.Message;
			feedback.Status = feedbackVm.Status;
			feedback.CreatedDate = DateTime.Now;
		}

		public static void UpdatePermission(this Permission permission, PermissionViewModel permissionVm)
		{
			permission.RoleId = permissionVm.RoleId;
			permission.FunctionId = permissionVm.FunctionId;
			permission.CanCreate = permissionVm.CanCreate;
			permission.CanDelete = permissionVm.CanDelete;
			permission.CanRead = permissionVm.CanRead;
			permission.CanUpdate = permissionVm.CanUpdate;
		}

		public static void UpdateApplicationRole(this AppRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
		{
			if (action == "update")
				appRole.Id = appRoleViewModel.Id;
			else
				appRole.Id = Guid.NewGuid().ToString();
			appRole.Name = appRoleViewModel.Name;
			appRole.Description = appRoleViewModel.Description;
		}

		public static void UpdateUser(this AppUser appUser, AppUserViewModel appUserViewModel, string action = "add")
		{
			appUser.Id = appUserViewModel.Id;
			appUser.FullName = appUserViewModel.FullName;
			appUser.BirthDay = appUserViewModel.BirthDay;
			//if (!string.IsNullOrEmpty(appUserViewModel.BirthDay))
			//{
			//	DateTime dateTime = DateTime.ParseExact(appUserViewModel.BirthDay, "dd/MM/yyyy", new CultureInfo("vi-VN"));
			//	appUser.BirthDay = dateTime;
			//}

			appUser.Email = appUserViewModel.Email;
			appUser.Address = appUserViewModel.Address;
			appUser.UserName = appUserViewModel.UserName;
			appUser.PhoneNumber = appUserViewModel.PhoneNumber;
			appUser.Gender = appUserViewModel.Gender;
			appUser.Status = appUserViewModel.Status;
			appUser.Address = appUserViewModel.Address;
			appUser.Avatar = appUserViewModel.Avatar;
		}
	}
}