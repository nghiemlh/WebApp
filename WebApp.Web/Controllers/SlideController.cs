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
	[RoutePrefix("api/slide")]
	public class SlideController : ApiControllerBase
	{
		private ISlideService _slideService;

		public SlideController(IErrorService errorService, ISlideService slideService) : base(errorService)
		{
			this._slideService = slideService;
		}

		[Route("getall")]
		[HttpGet]
		public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword = "")
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				var model = _slideService.GetAll(keyword).OrderBy(x => x.CreatedDate);
				IEnumerable<SlideViewModel> modelVm = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(model);
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
				var model = _slideService.GetAllStatus(keyword).OrderBy(x => x.CreatedDate);
				IEnumerable<SlideViewModel> modelVm = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(model);
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

			var slide = _slideService.GetById(id);
			if (slide == null)
				return request.CreateErrorResponse(HttpStatusCode.NoContent, "No data");

			var modelVm = Mapper.Map<Slide, SlideViewModel>(slide);
			return request.CreateResponse(HttpStatusCode.OK, modelVm);
		}

		[HttpPost]
		[Route("add")]
		public HttpResponseMessage Create(HttpRequestMessage request, SlideViewModel slideViewModel)
		{
			if (ModelState.IsValid)
			{
				var newSlide = new Slide();
				try
				{
					newSlide.UpdateSlide(slideViewModel);
					newSlide.CreatedDate = DateTime.Now;
					newSlide.CreatedBy = User.Identity.Name;

					_slideService.Add(newSlide);
					_slideService.Save();
					return request.CreateResponse(HttpStatusCode.OK, slideViewModel);
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
		public HttpResponseMessage Update(HttpRequestMessage request, SlideViewModel slideViewModel)
		{
			if (ModelState.IsValid)
			{
				var slide = _slideService.GetById(slideViewModel.Id);
				try
				{
					slide.UpdateSlide(slideViewModel);
					slide.UpdatedDate = DateTime.Now;
					slide.UpdatedBy = User.Identity.Name;
					_slideService.Update(slide);
					_slideService.Save();

					return request.CreateResponse(HttpStatusCode.OK, slide);
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
			_slideService.Delete(id);
			_slideService.Save();
			return request.CreateResponse(HttpStatusCode.OK, id);
		}
	}
}
