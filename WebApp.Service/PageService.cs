using System.Collections.Generic;
using System.Linq;
using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface IPageService
	{
		IEnumerable<Page> GetAll(string filter);

		bool CheckExistedAlias(string alias);

		Page Get(int id);

		Page GetByAlias(string alias);

		Page Add(Page page);

		void Update(Page page);

		void Delete(int id);

		void Save();
	}

	public class PageService : IPageService
	{
		private IPageRepository _pageRepository;
		private IUnitOfWork _unitOfWork;

		public PageService(IPageRepository pageRepository, IUnitOfWork unitOfWork)
		{
			this._pageRepository = pageRepository;
			this._unitOfWork = unitOfWork;
		}

		public bool CheckExistedAlias(string alias)
		{
			return _pageRepository.CheckContains(x => x.Alias == alias);
		}

		public Page Add(Page page)
		{
			return _pageRepository.Add(page);
		}

		public void Delete(int id)
		{
			var page = _pageRepository.GetSingleByCondition(x => x.Id == id);
			_pageRepository.Delete(page);
		}

		public IEnumerable<Page> GetAll(string filter)
		{
			if(!string.IsNullOrEmpty(filter))
				return _pageRepository.GetMulti(x => x.Status && x.Name.Contains(filter)).OrderBy(x => x.Name);
			else
				return _pageRepository.GetMulti(x => x.Status).OrderBy(x => x.Name);
		}

		public Page Get(int id)
		{
			return _pageRepository.GetSingleByCondition(x => x.Id == id);
		}

		public Page GetByAlias(string alias)
		{
			return _pageRepository.GetSingleByCondition(x => x.Alias == alias);
		}

		public void Update(Page page)
		{
			_pageRepository.Update(page);
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}
	}
}