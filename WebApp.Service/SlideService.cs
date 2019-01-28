using System.Collections.Generic;
using System.Linq;
using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface ISlideService
	{
		IEnumerable<Slide> GetAll(string filter);

		IEnumerable<Slide> GetAllStatus(string filter);

		Slide GetById(int id);

		Slide Add(Slide slide);

		void Update(Slide slide);

		void Delete(int id);

		void Save();
	}

	public class SlideService : ISlideService
	{
		private ISlideRepository _slideRepository;
		private IUnitOfWork _unitOfWork;

		public SlideService(ISlideRepository slideRepository, IUnitOfWork unitOfWork)
		{
			this._slideRepository = slideRepository;
			this._unitOfWork = unitOfWork;
		}

		public Slide Add(Slide slide)
		{
			return _slideRepository.Add(slide);
		}

		public void Delete(int id)
		{
			var size = _slideRepository.GetSingleByCondition(x => x.Id == id);
			_slideRepository.Delete(size);
		}

		public Slide GetById(int id)
		{
			return _slideRepository.GetSingleByCondition(x => x.Id == id);
		}

		public IEnumerable<Slide> GetAll(string filter)
		{
			if (!string.IsNullOrEmpty(filter))
				return _slideRepository.GetMulti(x => x.Status && x.Name.Contains(filter)).OrderBy(x => x.Name);
			else
				return _slideRepository.GetMulti(x => x.Status).OrderBy(x => x.Name);
		}

		public IEnumerable<Slide> GetAllStatus(string filter)
		{
			if (!string.IsNullOrEmpty(filter))
				return _slideRepository.GetMulti(x => x.Name.Contains(filter)).OrderBy(x => x.Name);
			else
				return _slideRepository.GetAll().OrderBy(x => x.Name);
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}

		public void Update(Slide slide)
		{
			_slideRepository.Update(slide);
		}
	}
}