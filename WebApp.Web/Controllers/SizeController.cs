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
	[Authorize]
	[RoutePrefix("api/size")]
	public class SizeController : ApiControllerBase
	{
		private ISizeService _sizeService;

		public SizeController(IErrorService errorService, ISizeService sizeService) : base(errorService)
		{
			this._sizeService = sizeService;
		}

		[Route("getall")]
		[HttpGet]
		public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword = "")
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				var model = _sizeService.GetAll(keyword).OrderBy(x => x.CreatedDate);
				IEnumerable<SizeViewModel> modelVm = Mapper.Map<IEnumerable<Size>, IEnumerable<SizeViewModel>>(model);
				response = request.CreateResponse(HttpStatusCode.OK, modelVm);
				return response;
			});
		}

		[Route("getallstatus")]
		[HttpGet]
		public HttpResponseMessage GetAllStatus(HttpRequestMessage request, string keyword = "")
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				var model = _sizeService.GetAllStatus(keyword).OrderBy(x => x.CreatedDate);
				IEnumerable<SizeViewModel> modelVm = Mapper.Map<IEnumerable<Size>, IEnumerable<SizeViewModel>>(model);
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

			var size = _sizeService.GetById(id);
			if (size == null)
				return request.CreateErrorResponse(HttpStatusCode.NoContent, "No data");

			var modelVm = Mapper.Map<Size, SizeViewModel>(size);
			return request.CreateResponse(HttpStatusCode.OK, modelVm);
		}

		[HttpPost]
		[Route("add")]
		public HttpResponseMessage Create(HttpRequestMessage request, SizeViewModel sizeViewModel)
		{
			if (ModelState.IsValid)
			{
				var newSize = new Size();
				try
				{
					newSize.UpdateSize(sizeViewModel);
					newSize.CreatedDate = DateTime.Now;
					newSize.CreatedBy = User.Identity.Name;

					_sizeService.Add(newSize);
					_sizeService.Save();
					return request.CreateResponse(HttpStatusCode.OK, sizeViewModel);
				}
				catch (Exception dex)
				{
					return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
				}
			}
			else
			{
				return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}
		}

		[HttpPut]
		[Route("update")]
		public HttpResponseMessage Update(HttpRequestMessage request, SizeViewModel SizeViewModel)
		{
			if (ModelState.IsValid)
			{
				var size = _sizeService.GetById(SizeViewModel.Id);
				try
				{
					size.UpdateSize(SizeViewModel);
					size.UpdatedDate = DateTime.Now;
					size.UpdatedBy = User.Identity.Name;
					_sizeService.Update(size);
					_sizeService.Save();

					return request.CreateResponse(HttpStatusCode.OK, size);
				}
				catch (Exception dex)
				{
					return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
				}
			}
			else
			{
				return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}
		}

		[HttpDelete]
		[Route("delete")]
		public HttpResponseMessage Delete(HttpRequestMessage request, int id)
		{
			_sizeService.Delete(id);
			_sizeService.Save();
			return request.CreateResponse(HttpStatusCode.OK, id);
		}
	}
}
