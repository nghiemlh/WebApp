using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Model.Models;
using WebApp.Service;
using WebApp.Web.Infrastructure.Core;
using WebApp.Web.Infrastructure.Extensions;
using WebApp.Web.Models;

namespace WebApp.Web.Controllers
{
	[RoutePrefix("api/objectcategory")]
	[Authorize]
	public class ObjectCategoryController : ApiControllerBase
	{
		#region Initialize

		private IObjectCategoryService _objectCategoryService;

		public ObjectCategoryController(IErrorService errorService, IObjectCategoryService objectCategoryService)
			: base(errorService)
		{
			this._objectCategoryService = objectCategoryService;
		}

		#endregion Initialize

		[Route("getall")]
		[HttpGet]
		public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword = "")
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				var model = _objectCategoryService.GetAll(keyword).OrderBy(x => x.CreatedDate);
				IEnumerable<ObjectCategoryViewModel> modelVm = Mapper.Map<IEnumerable<ObjectCategory>, IEnumerable<ObjectCategoryViewModel>>(model);
				response = request.CreateResponse(HttpStatusCode.OK, modelVm);
				return response;
			});
		}

		[Route("detail/{id}")]
		[HttpGet]
		public HttpResponseMessage Details(HttpRequestMessage request, int id)
		{
			if (string.IsNullOrEmpty(id.ToString()))
				return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");

			var objectCategory = _objectCategoryService.GetById(id);
			if (objectCategory == null)
				return request.CreateErrorResponse(HttpStatusCode.NoContent, "No data");

			var modelVm = Mapper.Map<ObjectCategory, ObjectCategoryViewModel>(objectCategory);
			return request.CreateResponse(HttpStatusCode.OK, modelVm);
		}

		[Route("add")]
		[HttpPost]
		public HttpResponseMessage Create(HttpRequestMessage request, ObjectCategoryViewModel objectCategoryVm)
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
					var newObjectCategory = new ObjectCategory();
					newObjectCategory.UpdateObjectCategory(objectCategoryVm);
					newObjectCategory.CreatedDate = DateTime.Now;
					newObjectCategory.CreatedBy = User.Identity.Name;

					_objectCategoryService.Add(newObjectCategory);
					_objectCategoryService.Save();

					var responseData = Mapper.Map<ObjectCategory, ObjectCategoryViewModel>(newObjectCategory);
					response = request.CreateResponse(HttpStatusCode.Created, responseData);
				}

				return response;
			});
		}

		[Route("update")]
		[HttpPut]
		public HttpResponseMessage Update(HttpRequestMessage request, ObjectCategoryViewModel objectCategoryVm)
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
					var dbObjectCategory = _objectCategoryService.GetById(objectCategoryVm.Id);

					dbObjectCategory.UpdateObjectCategory(objectCategoryVm);
					dbObjectCategory.UpdatedDate = DateTime.Now;
					dbObjectCategory.UpdatedBy = User.Identity.Name;

					_objectCategoryService.Update(dbObjectCategory);
					_objectCategoryService.Save();

					var responseData = Mapper.Map<ObjectCategory, ObjectCategoryViewModel>(dbObjectCategory);
					response = request.CreateResponse(HttpStatusCode.Created, responseData);
				}

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
					var oldObjectCategory = _objectCategoryService.Delete(id);
					_objectCategoryService.Save();

					var responseData = Mapper.Map<ObjectCategory, ObjectCategoryViewModel>(oldObjectCategory);
					response = request.CreateResponse(HttpStatusCode.Created, responseData);
				}

				return response;
			});
		}
	}
}
