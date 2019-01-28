using System.Collections.Generic;
using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface IPostCategoryService
	{
		PostCategory Add(PostCategory postCategory);

		void Update(PostCategory postCategory);

		PostCategory Delete(int id);

		IEnumerable<PostCategory> GetAll();

		IEnumerable<PostCategory> GetAllParent(string keyword);

		IEnumerable<PostCategory> GetLastParent(string keyword);

		IEnumerable<PostCategory> GetAllByParentId(int parentId);

		PostCategory GetById(int id);

		void Save();
	}

	public class PostCategoryService : IPostCategoryService
	{
		private IPostCategoryRepository _postCategoryRepository;
		private IUnitOfWork _unitOfWork;

		public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
		{
			this._postCategoryRepository = postCategoryRepository;
			this._unitOfWork = unitOfWork;
		}

		public PostCategory Add(PostCategory postCategory)
		{
			return _postCategoryRepository.Add(postCategory);
		}

		public void Update(PostCategory postCategory)
		{
			_postCategoryRepository.Update(postCategory);
		}

		public PostCategory Delete(int id)
		{
			return _postCategoryRepository.Delete(id);
		}

		public IEnumerable<PostCategory> GetAll()
		{
			return _postCategoryRepository.GetAll();
		}

		public IEnumerable<PostCategory> GetAllByParentId(int parentId)
		{
			return _postCategoryRepository.GetMulti(x => x.Status && x.ParentId == parentId);
		}

		public IEnumerable<PostCategory> GetAllParent(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
				return _postCategoryRepository.GetMulti(x => x.Status && (x.Name.Contains(keyword) || x.Description.Contains(keyword)) && (x.IsLast == false || x.IsLast == null));
			else
				return _postCategoryRepository.GetMulti(x => x.Status && (x.IsLast == false || x.IsLast == null));
		}

		public IEnumerable<PostCategory> GetLastParent(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
				return _postCategoryRepository.GetMulti(x => x.Status && (x.Name.Contains(keyword) || x.Description.Contains(keyword)) && x.IsLast == true);
			else
				return _postCategoryRepository.GetMulti(x => x.Status && x.IsLast == true);
		}

		public PostCategory GetById(int id)
		{
			return _postCategoryRepository.GetSingleById(id);
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}
	}
}