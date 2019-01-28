using System.Collections.Generic;
using System.Linq;
using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface IObjectService
	{
		Objects Add(Objects objects);

		void Update(Objects objects);

		Objects Delete(int id);

		IEnumerable<Objects> GetAll();

		IEnumerable<Objects> GetAll(string keyword);

		Objects GetById(int id);

		void Save();
	}

	public class ObjectService : IObjectService
	{
		private IObjectRepository _objectRepository;
		private IUnitOfWork _unitOfWork;

		public ObjectService(IObjectRepository objectRepository, IUnitOfWork unitOfWork)
		{
			this._objectRepository = objectRepository;
			this._unitOfWork = unitOfWork;
		}

		public Objects Add(Objects objects)
		{
			return _objectRepository.Add(objects);
		}

		public Objects Delete(int id)
		{
			return _objectRepository.Delete(id);
		}

		public IEnumerable<Objects> GetAll()
		{
			return _objectRepository.GetAll().OrderBy(x => x.CategoryId);
		}

		public IEnumerable<Objects> GetAll(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
				return _objectRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword)).OrderBy(x => x.CategoryId);
			else
				return _objectRepository.GetAll().OrderBy(x => x.CategoryId);
		}

		public Objects GetById(int id)
		{
			return _objectRepository.GetSingleById(id);
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}

		public void Update(Objects objects)
		{
			_objectRepository.Update(objects);
		}
	}
}