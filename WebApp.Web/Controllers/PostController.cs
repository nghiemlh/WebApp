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
	[RoutePrefix("api/post")]
	[Authorize]
	public class PostController : ApiControllerBase
	{
		#region Initialize

		private IPostService _postService;

		public PostController(IErrorService errorService, IPostService postService)
			: base(errorService)
		{
			this._postService = postService;
		}

		#endregion Initialize

		[Route("getall")]
		[HttpGet]
		public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword = "")
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				var model = _postService.GetAll(keyword).OrderBy(x => x.CreatedDate);
				IEnumerable<PostViewModel> modelVm = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(model);
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

			var post = _postService.GetById(id);
			if (post == null)
				return request.CreateErrorResponse(HttpStatusCode.NoContent, "No data");

			var modelVm = Mapper.Map<Post, PostViewModel>(post);
			return request.CreateResponse(HttpStatusCode.OK, modelVm);
		}

		[Route("add")]
		[HttpPost]
		public HttpResponseMessage Create(HttpRequestMessage request, PostViewModel postVm)
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
					var newPost = new Post();
					newPost.UpdatePost(postVm);
					newPost.CreatedDate = DateTime.Now;
					newPost.CreatedBy = User.Identity.Name;

					_postService.Add(newPost);
					_postService.Save();

					var responseData = Mapper.Map<Post, PostViewModel>(newPost);
					response = request.CreateResponse(HttpStatusCode.Created, responseData);
				}

				return response;
			});
		}

		[Route("update")]
		[HttpPut]
		public HttpResponseMessage Update(HttpRequestMessage request, PostViewModel postVm)
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
					var dbPost = _postService.GetById(postVm.Id);

					dbPost.UpdatePost(postVm);
					dbPost.UpdatedDate = DateTime.Now;
					dbPost.UpdatedBy = User.Identity.Name;

					_postService.Update(dbPost);
					_postService.Save();

					var responseData = Mapper.Map<Post, PostViewModel>(dbPost);
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
					var oldPost = _postService.Delete(id);
					_postService.Save();

					var responseData = Mapper.Map<Post, PostViewModel>(oldPost);
					response = request.CreateResponse(HttpStatusCode.Created, responseData);
				}

				return response;
			});
		}
	}
}
