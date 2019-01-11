﻿using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApp.Common.Exceptions;
using WebApp.Model.Models;
using WebApp.Service;
using WebApp.Web.App_Start;
using WebApp.Web.Infrastructure.Core;
using WebApp.Web.Infrastructure.Extensions;
using WebApp.Web.Models;
using WebApp.Web.Providers;

namespace WebApp.Web.Controllers
{
	[Authorize]
	[RoutePrefix("api/appUser")]
	public class AppUserController : ApiControllerBase
	{
		public AppUserController(IErrorService errorService)
			: base(errorService) { }

		[Route("getlistpaging")]
		[HttpGet]
		[Permission(Action = "Read", Function = "USER")]
		public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize, string filter = null)
		{
			return CreateHttpResponse(request, () =>
			{
				HttpResponseMessage response = null;
				int totalRow = 0;
				var model = AppUserManager.Users;
				if (!string.IsNullOrWhiteSpace(filter))
					model = model.Where(x => x.UserName.Contains(filter) || x.FullName.Contains(filter));

				totalRow = model.Count();
				var data = model.OrderBy(x => x.FullName).Skip((page - 1) * pageSize).Take(pageSize);
				IEnumerable<AppUserViewModel> modelVm = Mapper.Map<IEnumerable<AppUser>, IEnumerable<AppUserViewModel>>(data);
				PaginationSet<AppUserViewModel> pagedSet = new PaginationSet<AppUserViewModel>()
				{
					PageIndex = page,
					PageSize = pageSize,
					TotalRows = totalRow,
					Items = modelVm,
				};

				response = request.CreateResponse(HttpStatusCode.OK, pagedSet);
				return response;
			});
		}

		[Route("detail/{id}")]
		[HttpGet]
		//[Authorize(Roles = "ViewUser")]
		[Permission(Action = "Read", Function = "USER")]
		public async Task<HttpResponseMessage> Details(HttpRequestMessage request, string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");
			}
			var user = await AppUserManager.FindByIdAsync(id);
			if (user == null)
			{
				return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không có dữ liệu");
			}
			else
			{
				var roles = await AppUserManager.GetRolesAsync(user.Id);
				var applicationUserViewModel = Mapper.Map<AppUser, AppUserViewModel>(user);
				applicationUserViewModel.Roles = roles;
				return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);
			}
		}

		[HttpPost]
		[Route("add")]
		//[Authorize(Roles = "AddUser")]
		[Permission(Action = "Create", Function = "USER")]
		public async Task<HttpResponseMessage> Create(HttpRequestMessage request, AppUserViewModel applicationUserViewModel)
		{
			if (ModelState.IsValid)
			{
				var newAppUser = new AppUser();
				newAppUser.UpdateUser(applicationUserViewModel);
				try
				{
					newAppUser.Id = Guid.NewGuid().ToString();
					var result = await AppUserManager.CreateAsync(newAppUser, applicationUserViewModel.Password);
					if (result.Succeeded)
					{
						var roles = applicationUserViewModel.Roles.ToArray();
						await AppUserManager.AddToRolesAsync(newAppUser.Id, roles);

						return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);
					}
					else
						return request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Join(",", result.Errors));
				}
				catch (NameDuplicatedException dex)
				{
					return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
				}
				catch (Exception ex)
				{
					return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
				}
			}
			else
			{
				return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}
		}

		[HttpPut]
		[Route("update")]
		//[Authorize(Roles = "UpdateUser")]
		[Permission(Action = "Update", Function = "USER")]
		public async Task<HttpResponseMessage> Update(HttpRequestMessage request, AppUserViewModel applicationUserViewModel)
		{
			if (ModelState.IsValid)
			{
				var appUser = await AppUserManager.FindByIdAsync(applicationUserViewModel.Id);
				try
				{
					appUser.UpdateUser(applicationUserViewModel);
					var result = await AppUserManager.UpdateAsync(appUser);
					if (result.Succeeded)
					{
						var userRoles = await AppUserManager.GetRolesAsync(appUser.Id);
						var selectedRole = applicationUserViewModel.Roles.ToArray();

						selectedRole = selectedRole ?? new string[] { };

						await AppUserManager.RemoveFromRolesAsync(appUser.Id, userRoles.Except(selectedRole).ToArray());
						await AppUserManager.AddToRolesAsync(appUser.Id, selectedRole.Except(userRoles).ToArray());
						return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);
					}
					else
						return request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Join(",", result.Errors));
				}
				catch (NameDuplicatedException dex)
				{
					return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
				}
			}
			else
			{
				return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}
		}

		[HttpPost]
		[Route("changepassword")]
		//[Authorize(Roles = "UpdateUser")]
		[Permission(Action = "Update", Function = "USER")]
		public async Task<HttpResponseMessage> ChangePassword(HttpRequestMessage request, string username, string newpassword)
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
						AppUserManager.RemovePassword(appUser.Id);
						var result = await AppUserManager.AddPasswordAsync(appUser.Id, newpassword);
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

		[HttpDelete]
		[Route("delete")]
		//[Authorize(Roles ="DeleteUser")]
		[Permission(Action = "Delete", Function = "USER")]
		public async Task<HttpResponseMessage> Delete(HttpRequestMessage request, string id)
		{
			var appUser = await AppUserManager.FindByIdAsync(id);
			var result = await AppUserManager.DeleteAsync(appUser);
			if (result.Succeeded)
				return request.CreateResponse(HttpStatusCode.OK, id);
			else
				return request.CreateErrorResponse(HttpStatusCode.OK, string.Join(",", result.Errors));
		}
	}
}