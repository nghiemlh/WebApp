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
	[RoutePrefix("api/object")]
	[Authorize]
	public class ObjectController : ApiControllerBase
	{
		#region Initialize

		private IObjectService _objectService;

		public ObjectController(IErrorService errorService, IObjectService objectService)
			: base(errorService)
		{
			this._objectService = objectService;
		}

		#endregion Initialize

		[Route("getall")]
		[HttpGet]
		public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword = "")
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				var model = _objectService.GetAll(keyword).OrderBy(x => x.CreatedDate);
				IEnumerable<ObjectViewModel> modelVm = Mapper.Map<IEnumerable<Objects>, IEnumerable<ObjectViewModel>>(model);
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

			var objects = _objectService.GetById(id);
			if (objects == null)
				return request.CreateErrorResponse(HttpStatusCode.NoContent, "No data");

			var modelVm = Mapper.Map<Objects, ObjectViewModel>(objects);
			return request.CreateResponse(HttpStatusCode.OK, modelVm);
		}

		[Route("add")]
		[HttpPost]
		public HttpResponseMessage Create(HttpRequestMessage request, ObjectViewModel objectVm)
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
					var newObject = new Objects();
					newObject.UpdateObject(objectVm);
					newObject.CreatedDate = DateTime.Now;
					newObject.CreatedBy = User.Identity.Name;

					_objectService.Add(newObject);
					_objectService.Save();

					var responseData = Mapper.Map<Objects, ObjectViewModel>(newObject);
					response = request.CreateResponse(HttpStatusCode.Created, responseData);
				}

				return response;
			});
		}

		[Route("update")]
		[HttpPut]
		public HttpResponseMessage Update(HttpRequestMessage request, ObjectViewModel objectVm)
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
					var dbObject = _objectService.GetById(objectVm.Id);

					dbObject.UpdateObject(objectVm);
					dbObject.UpdatedDate = DateTime.Now;
					dbObject.UpdatedBy = User.Identity.Name;

					_objectService.Update(dbObject);
					_objectService.Save();

					var responseData = Mapper.Map<Objects, ObjectViewModel>(dbObject);
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
					var oldObject = _objectService.Delete(id);
					_objectService.Save();

					var responseData = Mapper.Map<Objects, ObjectViewModel>(oldObject);
					response = request.CreateResponse(HttpStatusCode.Created, responseData);
				}

				return response;
			});
		}
	}
}
