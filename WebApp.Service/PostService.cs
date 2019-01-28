using System.Collections.Generic;
using System.Linq;
using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface IPostService
	{
		void Add(Post post);

		void Update(Post post);

		Post Delete(int id);

		IEnumerable<Post> GetAll();

		IEnumerable<Post> GetAll(string keyword);

		IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);

		IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow);

		Post GetById(int id);

		IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);

		void Save();
	}

	public class PostService : IPostService
	{
		private IPostRepository _postRepository;
		private IUnitOfWork _unitOfWork;

		public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
		{
			this._postRepository = postRepository;
			this._unitOfWork = unitOfWork;
		}

		public void Add(Post post)
		{
			_postRepository.Add(post);
		}

		public Post Delete(int id)
		{
			return _postRepository.Delete(id);
		}

		public IEnumerable<Post> GetAll()
		{
			return _postRepository.GetAll(new string[] { "PostCategory" });
		}

		public IEnumerable<Post> GetAll(string keyword)
		{
			if (!string.IsNullOrEmpty(keyword))
				return _postRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword)).OrderBy(x => x.CategoryId);
			else
				return _postRepository.GetAll().OrderBy(x => x.CategoryId);
		}

		public IEnumerable<Post> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow)
		{
			return _postRepository.GetMultiPaging(x => x.Status && x.CategoryId == categoryId, out totalRow, page, pageSize, new string[] { "PostCategory" });
		}

		public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
		{
			//TODO: Select all post by tag
			return _postRepository.GetAllByTag(tag, page, pageSize, out totalRow);
		}

		public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
		{
			return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
		}

		public Post GetById(int id)
		{
			return _postRepository.GetSingleById(id);
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}

		public void Update(Post post)
		{
			_postRepository.Update(post);
		}
	}
}