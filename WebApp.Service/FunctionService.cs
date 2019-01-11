using System.Collections.Generic;
using System.Linq;
using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface IFunctionService
	{
		IEnumerable<Function> GetAll(string filter);

		IEnumerable<Function> GetAllStatus(string filter);

		IEnumerable<Function> GetAllParent(string filter);

		IEnumerable<Function> GetAllWithPermission(string userId);

		IEnumerable<Function> GetAllWithParentID(string parentId);

		Function Get(string id);

		Function Create(Function function);

		void Update(Function function);

		void Delete(string id);

		void Save();

		bool CheckExistedId(string id);
	}

	public class FunctionService : IFunctionService
	{
		private IFunctionRepository _functionRepository;
		private IUnitOfWork _unitOfWork;

		public FunctionService(IFunctionRepository functionRepository, IUnitOfWork unitOfWork)
		{
			_functionRepository = functionRepository;
			_unitOfWork = unitOfWork;
		}

		public bool CheckExistedId(string id)
		{
			return _functionRepository.CheckContains(x => x.Id == id);
		}

		public Function Create(Function function)
		{
			return _functionRepository.Add(function);
		}

		public void Update(Function function)
		{
			_functionRepository.Update(function);
		}

		public void Delete(string id)
		{
			var function = _functionRepository.GetSingleByCondition(x => x.Id == id);
			_functionRepository.Delete(function);
		}

		public Function Get(string id)
		{
			return _functionRepository.GetSingleByCondition(x => x.Id == id);
		}

		public IEnumerable<Function> GetAll(string filter)
		{
			var query = _functionRepository.GetMulti(x => x.Status);
			if (!string.IsNullOrEmpty(filter))
				query = query.Where(x => x.Name.Contains(filter));
			return query.OrderBy(x => x.ParentId);
		}

		public IEnumerable<Function> GetAllParent(string filter)
		{
			if (!string.IsNullOrEmpty(filter))
				return _functionRepository.GetMulti(x => x.Status && (x.IsLast == false || x.IsLast == null) && x.Name.Contains(filter)).OrderBy(x => x.DisplayOrder);
			else
				return _functionRepository.GetMulti(x => x.Status && (x.IsLast == false || x.IsLast == null)).OrderBy(x => x.DisplayOrder);
		}

		public IEnumerable<Function> GetAllStatus(string filter)
		{
			var query = _functionRepository.GetAll();
			if (!string.IsNullOrEmpty(filter))
				query = query.Where(x => x.Name.Contains(filter));
			return query.OrderBy(x => x.ParentId);
		}

		public IEnumerable<Function> GetAllWithParentID(string parentId)
		{
			return _functionRepository.GetMulti(x => x.ParentId == parentId);
		}

		public IEnumerable<Function> GetAllWithPermission(string userId)
		{
			var query = _functionRepository.GetListFunctionWithPermission(userId);
			return query.OrderBy(x => x.ParentId);
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}
	}
}