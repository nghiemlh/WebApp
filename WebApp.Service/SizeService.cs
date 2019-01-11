using System.Collections.Generic;
using System.Linq;
using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface ISizeService
	{
		IEnumerable<Size> GetAll(string filter);

		IEnumerable<Size> GetAllStatus(string filter);

		Size GetById(int id);

		Size Add(Size size);

		void Update(Size size);

		void Delete(int id);

		void Save();
	}

	public class SizeService : ISizeService
	{
		private ISizeRepository _sizeRepository;
		private IUnitOfWork _unitOfWork;

		public SizeService(ISizeRepository sizeRepository, IUnitOfWork unitOfWork)
		{
			this._sizeRepository = sizeRepository;
			this._unitOfWork = unitOfWork;
		}

		public Size Add(Size size)
		{
			return _sizeRepository.Add(size);
		}

		public void Delete(int id)
		{
			var size = _sizeRepository.GetSingleByCondition(x => x.Id == id);
			_sizeRepository.Delete(size);
		}

		public Size GetById(int id)
		{
			return _sizeRepository.GetSingleByCondition(x => x.Id == id);
		}

		public IEnumerable<Size> GetAll(string filter)
		{
			if (!string.IsNullOrEmpty(filter))
				return _sizeRepository.GetMulti(x => x.Status && x.Name.Contains(filter)).OrderBy(x => x.Name);
			else
				return _sizeRepository.GetMulti(x => x.Status).OrderBy(x => x.Name);
		}

		public IEnumerable<Size> GetAllStatus(string filter)
		{
			if (!string.IsNullOrEmpty(filter))
				return _sizeRepository.GetMulti(x => x.Name.Contains(filter)).OrderBy(x => x.Name);
			else
				return _sizeRepository.GetAll().OrderBy(x => x.Name);
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}

		public void Update(Size size)
		{
			_sizeRepository.Update(size);
		}
	}
}