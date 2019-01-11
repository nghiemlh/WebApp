using System.Collections.Generic;
using System.Linq;
using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface IProductQuantityService
	{
		void Add(ProductQuantity productQuantity);

		void Delete(int id);

		List<ProductQuantity> GetAll(int productId, int? colorId, int? sizeId);

		bool CheckExist(int productId, int? colorId, int? sizeId);

		List<Size> GetListSize();

		List<Color> GetListColor();

		void Save();
	}

	public class ProductQuantityService : IProductQuantityService
	{
		private IProductQuantityRepository _productQuantityRepository;
		private IColorRepository _colorRepository;
		private ISizeRepository _sizeRepository;
		private IUnitOfWork _unitOfWork;

		public ProductQuantityService(IProductQuantityRepository productQuantityRepository,
			IColorRepository colorRepository, ISizeRepository sizeRepository,
			IUnitOfWork unitOfWork)
		{
			this._productQuantityRepository = productQuantityRepository;
			_sizeRepository = sizeRepository;
			_colorRepository = colorRepository;
			this._unitOfWork = unitOfWork;
		}

		public void Add(ProductQuantity productQuantity)
		{
			_productQuantityRepository.Add(productQuantity);
		}

		public bool CheckExist(int productId, int? colorId, int? sizeId)
		{
			if (!colorId.HasValue && !sizeId.HasValue)
				return _productQuantityRepository.CheckContains(x => x.ProductId == productId && x.ColorId == null && x.SizeId == null);
			else if (colorId.HasValue && !sizeId.HasValue)
				return _productQuantityRepository.CheckContains(x => x.ProductId == productId && x.ColorId == colorId && x.SizeId == null);
			else if (!colorId.HasValue && sizeId.HasValue)
				return _productQuantityRepository.CheckContains(x => x.ProductId == productId && x.ColorId == null && x.SizeId == sizeId);
			else
				return _productQuantityRepository.CheckContains(x => x.ProductId == productId && x.ColorId == colorId && x.SizeId == sizeId);
		}

		public void Delete(int id)
		{
			var productQuantity = _productQuantityRepository.GetSingleByCondition(x => x.Id == id);
			_productQuantityRepository.Delete(productQuantity);
		}

		public List<ProductQuantity> GetAll(int productId, int? colorId, int? sizeId)
		{
			var query = _productQuantityRepository.GetMulti(x => x.ProductId == productId, new string[] { "Color", "Size" });
			if (sizeId.HasValue)
				query = query.Where(x => x.SizeId == sizeId.Value);
			if (colorId.HasValue)
				query = query.Where(x => x.ColorId == colorId.Value);
			return query.ToList();
		}

		public List<Color> GetListColor()
		{
			return _colorRepository.GetAll().ToList();
		}

		public List<Size> GetListSize()
		{
			return _sizeRepository.GetAll().ToList();
		}

		public void Save()
		{
			_unitOfWork.Commit();
		}
	}
}