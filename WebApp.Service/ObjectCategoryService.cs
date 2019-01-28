using System.Collections.Generic;
using System.Linq;
using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface IObjectCategoryService
	{
		ObjectCategory Add(ObjectCategory objectCategory);

		void Update(ObjectCategory objectCategory);

		ObjectCategory Delete(int id);

		IEnumerable<ObjectCategory> GetAll();

		IEnumerable<ObjectCategory> GetAll(string keyword);

		IEnumerable<ObjectCategory> GetAllParent(string keyword);

		IEnumerable<ObjectCategory> GetLastParent(string keyword);

		IEnumerable<ObjectCategory> GetAllByParentId(int parentId);

		ObjectCategory GetById(int id);

		void Save();
	}

	public class ObjectCategoryService : IObjectCategoryService
	{
		private IObjectCategoryRepository _objectCategoryRepository;
		private IUnitOfWork _unitOfWork;

		public ObjectCategoryService(IObjectCategoryRepository objectCategoryRepository, IUnitOfWork unitOfWork)
		{
			this._objectCategoryRepository = objectCategoryRepository;
			this._unitOfWork = unitOfWork;
		}

		public ObjectCategory Add(ObjectCategory objectCategory)
		{
			return _objectCategoryRepository.Add(objectCategory);
		}

		public ObjectCategory Delete(int id)
		{
			return _objectCategoryRepository.Delete(id);
		}

		public IEnumerable<ObjectCategory> GetAll()
		{
			return _objectCategoryRepository.GetAll().OrderBy(x => x.ParentId);
		}

		public IEnumerable<ObjectCategory> GetAll(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
				return _objectCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword)).OrderBy(x => x.ParentId);
			else
				return _objectCategoryRepository.GetAll().OrderBy(x => x.ParentId);
		}

		public IEnumerable<ObjectCategory> GetAllByParentId(int parentId)
		{
			return _objectCategoryRepository.GetMulti(x => x.Status && x.ParentId == parentId);
		}

		public IEnumerable<ObjectCategory> GetAllParent(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
				return _objectCategoryRepository.GetMulti(x => x.Status && (x.Name.Contains(keyword) || x.Description.Contains(keyword)) && (x.IsLast == false || x.IsLast == null));
			else
				return _objectCategoryRepository.GetMulti(x => x.Status && (x.IsLast == false || x.IsLast == null));
		}

		public ObjectCategory GetById(int id)
		{
			return _objectCategoryRepository.GetSingleById(id);
		}

		public IEnumerable<ObjectCategory> GetLastParent(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
				return _objectCategoryRepository.GetMulti(x => x.Status && (x.Name.Contains(keyword) || x.Description.Contains(keyword)) && x.IsLast == true);
			else
				return _objectCategoryRepository.GetMulti(x => x.Status && x.IsLast == true);
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}

		public void Update(ObjectCategory objectCategory)
		{
			_objectCategoryRepository.Update(objectCategory);
		}
	}
}