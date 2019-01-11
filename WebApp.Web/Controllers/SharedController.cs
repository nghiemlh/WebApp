using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApp.Common.Exceptions;
using WebApp.Model.Models;
using WebApp.Service;
using WebApp.Web.Infrastructure.Core;
using WebApp.Web.Models;

namespace WebApp.Web.Controllers
{
	[RoutePrefix("api/shared")]
	public class SharedController : ApiControllerBase
	{
		private IProductCategoryService _productCategoryService;
		private IFunctionService _functionService;

		public SharedController(IErrorService errorService,
								IProductCategoryService productCategoryService,
								IFunctionService functionService) : base(errorService)
		{
			_productCategoryService = productCategoryService;
			_functionService = functionService;
		}

		[HttpGet]
		[Route("getallparentfunction")]
		public HttpResponseMessage GetAllParentFunction(HttpRequestMessage request, string filter = "")
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				var model = _functionService.GetAllParent(filter);
				IEnumerable<FunctionViewModel> modelVm = Mapper.Map<IEnumerable<Function>, IEnumerable<FunctionViewModel>>(model);
				response = request.CreateResponse(HttpStatusCode.OK, modelVm);
				return response;
			});
		}

		[Route("getallparentproductcategory")]
		[HttpGet]
		public HttpResponseMessage GetAllParentProductCategory(HttpRequestMessage request, string filter = "")
		{
			return CreateHttpResponse(request, () =>
			{
				var model = _productCategoryService.GetAllParent(filter);
				var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
				var response = request.CreateResponse(HttpStatusCode.OK, responseData);
				return response;
			});
		}

		[Route("getlastparentproductcategory")]
		[HttpGet]
		public HttpResponseMessage GetLastProductCategory(HttpRequestMessage request, string filter = "")
		{
			return CreateHttpResponse(request, () =>
			{
				var model = _productCategoryService.GetLastParent(filter);

				var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
				var response = request.CreateResponse(HttpStatusCode.OK, responseData);
				return response;
			});
		}

		[Route("getallproduct")]
		[HttpGet]
		public HttpResponseMessage GetAllProduct(HttpRequestMessage request, string filter = "")
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				var model = _functionService.GetAll(filter).OrderBy(x => x.DisplayOrder);
				IEnumerable<FunctionViewModel> modelVm = Mapper.Map<IEnumerable<Function>, IEnumerable<FunctionViewModel>>(model);
				response = request.CreateResponse(HttpStatusCode.OK, modelVm);
				return response;
			});
		}

		[HttpPost]
		[Route("changepassword")]
		public async Task<HttpResponseMessage> ChangePassword(HttpRequestMessage request, string username, string currentpassword, string newpassword)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = await AppUserManager.FindByNameAsync(username);
				if (appUser.Id == string.Empty || appUser.Id == null)
				{
					return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Tên đăng nhập không tồn tại.");
				}
				else
				{
					try
					{
						var result = await AppUserManager.ChangePasswordAsync(appUser.Id, currentpassword, newpassword);
						if (result.Succeeded)
							return request.CreateResponse(HttpStatusCode.OK, "Đổi mật khẩu thành công!");
						else
							return request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Join(",", result.Errors));
					}
					catch (NameDuplicatedException dex)
					{
						return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
					}
				}
			}
			else
			{
				return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}
		}
	}
}