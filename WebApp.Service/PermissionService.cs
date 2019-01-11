using System.Collections.Generic;
using System.Linq;
using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface IPermissionService
	{
		ICollection<Permission> GetAll(string keyword);

		ICollection<Permission> GetByFunctionId(string functionId);

		ICollection<Permission> GetByUserId(string userId);

		Permission Delete(int id);

		void Add(Permission permission);

		void DeleteAll(string functionId);

		void Save();
	}

	public class PermissionService : IPermissionService
	{
		private IPermissionRepository _permissionRepository;
		private IUnitOfWork _unitOfWork;

		public PermissionService(IPermissionRepository permissionRepository, IUnitOfWork unitOfWork)
		{
			this._permissionRepository = permissionRepository;
			this._unitOfWork = unitOfWork;
		}

		public void Add(Permission permission)
		{
			_permissionRepository.Add(permission);
		}

		public Permission Delete(int id)
		{
			return _permissionRepository.Delete(id);
		}

		public void DeleteAll(string functionId)
		{
			_permissionRepository.DeleteMulti(x => x.FunctionId == functionId);
		}

		public ICollection<Permission> GetAll(string keyword)
		{
			var query = _permissionRepository.GetAll(new string[] { "AppRole", "AppRole" });
			if (!string.IsNullOrEmpty(keyword))
				query = query.Where(x => x.FunctionId.Contains(keyword) || x.AppRole.Name.Contains(keyword));

			return query.ToList();
		}

		public ICollection<Permission> GetByFunctionId(string functionId)
		{
			return _permissionRepository
				.GetMulti(x => x.FunctionId == functionId, new string[] { "AppRole", "AppRole" }).ToList();
		}

		public ICollection<Permission> GetByUserId(string userId)
		{
			return _permissionRepository.GetByUserId(userId);
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}
	}
}