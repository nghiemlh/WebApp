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
	[RoutePrefix("api/color")]
	public class ColorController : ApiControllerBase
	{
		private IColorService _colorService;

		public ColorController(IErrorService errorService, IColorService colorService) : base(errorService)
		{
			this._colorService = colorService;
		}

		[Route("getall")]
		[HttpGet]
		public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword = "")
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				var model = _colorService.GetAll(keyword).OrderBy(x => x.CreatedDate);
				IEnumerable<ColorViewModel> modelVm = Mapper.Map<IEnumerable<Color>, IEnumerable<ColorViewModel>>(model);
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
				var model = _colorService.GetAllStatus(keyword).OrderBy(x => x.CreatedDate);
				IEnumerable<ColorViewModel> modelVm = Mapper.Map<IEnumerable<Color>, IEnumerable<ColorViewModel>>(model);
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

			var color = _colorService.GetById(id);
			if (color == null)
				return request.CreateErrorResponse(HttpStatusCode.NoContent, "No data");

			var modelVm = Mapper.Map<Color, ColorViewModel>(color);
			return request.CreateResponse(HttpStatusCode.OK, modelVm);
		}

		[HttpPost]
		[Route("add")]
		public HttpResponseMessage Create(HttpRequestMessage request, ColorViewModel colorViewModel)
		{
			if (ModelState.IsValid)
			{
				var newColor = new Color();
				try
				{
					newColor.UpdateColor(colorViewModel);
					newColor.CreatedDate = DateTime.Now;
					newColor.CreatedBy = User.Identity.Name;

					_colorService.Add(newColor);
					_colorService.Save();
					return request.CreateResponse(HttpStatusCode.OK, colorViewModel);					
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
		public HttpResponseMessage Update(HttpRequestMessage request, ColorViewModel colorViewModel)
		{
			if (ModelState.IsValid)
			{
				var color = _colorService.GetById(colorViewModel.Id);
				try
				{
					color.UpdateColor(colorViewModel);
					color.UpdatedDate = DateTime.Now;
					color.UpdatedBy = User.Identity.Name;
					_colorService.Update(color);
					_colorService.Save();

					return request.CreateResponse(HttpStatusCode.OK, color);
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
			_colorService.Delete(id);
			_colorService.Save();
			return request.CreateResponse(HttpStatusCode.OK, id);
		}
	}
}
