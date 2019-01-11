using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Model.Models;
using WebApp.Service;
using WebApp.Web.Infrastructure.Core;
using WebApp.Web.Models;
using WebApp.Web.Providers;

namespace WebApp.Web.Controllers
{
	[Authorize]
	[RoutePrefix("api/permission")]
	public class PermissionController : ApiControllerBase
	{
		#region Initialize
		private IPermissionService _permissionService;

		public PermissionController(IErrorService errorService, IPermissionService permissionService)
			: base(errorService) {
			this._permissionService = permissionService;
		}
		#endregion

		[Route("getall")]
		[HttpGet]
		public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
		{
			return CreateHttpResponse(request, () =>
			{
				int totalRow = 0;
				var model = _permissionService.GetAll(keyword);

				totalRow = model.Count();
				var query = model.OrderBy(x => x.FunctionId).Skip(page - 1 * pageSize).Take(pageSize).ToList();

				var responseData = Mapper.Map<List<Permission>, List<PermissionViewModel>>(query);

				var paginationSet = new PaginationSet<PermissionViewModel>()
				{
					Items = responseData,
					PageIndex = page,
					TotalRows = totalRow,
					PageSize = pageSize
				};
				var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
				return response;
			});
		}

		[Route("delete")]
		[HttpDelete]
		public HttpResponseMessage Delete(HttpRequestMessage request, int id)
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				if (!ModelState.IsValid)
				{
					response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
				}
				else
				{
					var oldPermission = _permissionService.Delete(id);
					_permissionService.Save();

					var responseData = Mapper.Map<Permission, PermissionViewModel>(oldPermission);
					response = request.CreateResponse(HttpStatusCode.Created, responseData);
				}

				return response;
			});
		}
	}
}