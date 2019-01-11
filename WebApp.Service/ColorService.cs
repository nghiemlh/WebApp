using System.Collections.Generic;
using System.Linq;
using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface IColorService
	{
		IEnumerable<Color> GetAll(string filter);

		IEnumerable<Color> GetAllStatus(string filter);

		Color GetById(int id);

		Color Add(Color color);

		void Update(Color color);

		void Delete(int id);

		void Save();
	}

	public class ColorService : IColorService
	{
		private IColorRepository _colorRepository;
		private IUnitOfWork _unitOfWork;

		public ColorService(IColorRepository colorRepository, IUnitOfWork unitOfWork)
		{
			this._colorRepository = colorRepository;
			this._unitOfWork = unitOfWork;
		}

		public Color Add(Color color)
		{
			return _colorRepository.Add(color);
		}

		public void Delete(int id)
		{
			var page = _colorRepository.GetSingleByCondition(x => x.Id == id);
			_colorRepository.Delete(page);
		}

		public Color GetById(int id)
		{
			return _colorRepository.GetSingleByCondition(x => x.Id == id);
		}

		public IEnumerable<Color> GetAll(string filter)
		{
			if(!string.IsNullOrEmpty(filter))
				return _colorRepository.GetMulti(x => x.Status && x.Name.Contains(filter)).OrderBy(x => x.Name);
			else
				return _colorRepository.GetMulti(x => x.Status).OrderBy(x => x.Name);
		}

		public IEnumerable<Color> GetAllStatus(string filter)
		{
			if (!string.IsNullOrEmpty(filter))
				return _colorRepository.GetMulti(x => x.Name.Contains(filter)).OrderBy(x => x.Name);
			else
				return _colorRepository.GetAll().OrderBy(x => x.Name);
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}

		public void Update(Color color)
		{
			_colorRepository.Update(color);
		}
	}
}