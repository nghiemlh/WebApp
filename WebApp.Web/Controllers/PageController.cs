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
	[RoutePrefix("api/page")]
	public class PageController : ApiControllerBase
	{
		private IPageService _pageService;

		public PageController(IErrorService errorService, IPageService pageService) : base(errorService)
		{
			this._pageService = pageService;
		}

		[Route("getall")]
		[HttpGet]
		public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword = "")
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				var model = _pageService.GetAll(keyword).OrderBy(x => x.CreatedDate);
				IEnumerable<PageViewModel> modelVm = Mapper.Map<IEnumerable<Page>, IEnumerable<PageViewModel>>(model);
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

			var page = _pageService.Get(id);
			if (page == null)
				return request.CreateErrorResponse(HttpStatusCode.NoContent, "No data");

			var modelVm = Mapper.Map<Page, PageViewModel>(page);
			return request.CreateResponse(HttpStatusCode.OK, modelVm);
		}

		[HttpPost]
		[Route("add")]
		public HttpResponseMessage Create(HttpRequestMessage request, PageViewModel PageViewModel)
		{
			if (ModelState.IsValid)
			{
				var newPage = new Page();
				try
				{
					if (_pageService.CheckExistedAlias(PageViewModel.Alias))
					{
						return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Alias đã tồn tại");
					}
					else
					{
						newPage.UpdatePage(PageViewModel);
						newPage.CreatedDate = DateTime.Now;
						newPage.CreatedBy = User.Identity.Name;

						_pageService.Add(newPage);
						_pageService.Save();
						return request.CreateResponse(HttpStatusCode.OK, PageViewModel);
					}
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
		public HttpResponseMessage Update(HttpRequestMessage request, PageViewModel PageViewModel)
		{
			if (ModelState.IsValid)
			{
				var page = _pageService.Get(PageViewModel.Id);
				try
				{
					page.UpdatePage(PageViewModel);
					page.UpdatedDate = DateTime.Now;
					page.UpdatedBy = User.Identity.Name;
					_pageService.Update(page);
					_pageService.Save();

					return request.CreateResponse(HttpStatusCode.OK, page);
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
			_pageService.Delete(id);
			_pageService.Save();
			return request.CreateResponse(HttpStatusCode.OK, id);
		}
	}
}