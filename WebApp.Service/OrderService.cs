using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WebApp.Data.Infrastructure;
using WebApp.Data.Repositories;
using WebApp.Model.Models;

namespace WebApp.Service
{
	public interface IOrderService
	{
		List<Order> GetList(string startDate, string endDate, string customerName,
			int pageIndex, int pageSize, out int totalRow);

		Order GetDetail(int Id);

		Order Create(Order order);

		void Update(Order order);

		void Delete(int Id);

		OrderDetail CreateDetail(OrderDetail order);

		void UpdateDetail(OrderDetail orderDetail);

		void DeleteDetail(int orderId);

		void DeleteDetail(int orderId, int displayOrder);

		void DeleteDetail(int productId, int orderId, int colorId, int sizeId);

		void UpdateStatus(int Id);

		List<OrderDetail> GetOrderDetails(int orderId);

		bool CheckExistDetail(int id, int displayOrder);

		void Save();
	}

	public class OrderService : IOrderService
	{
		private IOrderRepository _orderRepository;
		private IOrderDetailRepository _orderDetailRepository;
		private IUnitOfWork _unitOfWork;

		public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
		{
			this._orderRepository = orderRepository;
			this._orderDetailRepository = orderDetailRepository;
			this._unitOfWork = unitOfWork;
		}

		public List<Order> GetList(string startDate, string endDate, string customerName,
			int pageIndex, int pageSize, out int totalRow)
		{
			var query = _orderRepository.GetAll();
			if (!string.IsNullOrEmpty(startDate))
			{
				DateTime start = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
				query = query.Where(x => x.CreatedDate >= start);
			}
			if (!string.IsNullOrEmpty(endDate))
			{
				DateTime end = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
				query = query.Where(x => x.CreatedDate <= end);
			}

			totalRow = query.Count();
			return query.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
		}

		public Order Create(Order order)
		{
			try
			{
				_orderRepository.Add(order);
				_unitOfWork.Commit();
				return order;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public void Update(Order order)
		{
			_orderRepository.Update(order);
		}

		public void UpdateStatus(int Id)
		{
			var order = _orderRepository.GetSingleById(Id);
			order.Status = true;
			_orderRepository.Update(order);
		}

		//public Order GetDetail(int Id)
		//{
		//	return _orderRepository.GetSingleByCondition(x => x.Id == Id, new string[] { "OrderDetails" });
		//}

		public Order GetDetail(int Id)
		{
			return _orderRepository.GetSingleById(Id);
		}

		public void Delete(int id)
		{
			DeleteDetail(id);
			_orderRepository.Delete(id);
		}

		public List<OrderDetail> GetOrderDetails(int orderId)
		{
			return _orderDetailRepository.GetMulti(x => x.OrderId == orderId, new string[] { "Order", "Color", "Size", "Product" }).ToList();
		}

		public OrderDetail CreateDetail(OrderDetail orderDetail)
		{
			return _orderDetailRepository.Add(orderDetail);
		}

		public void UpdateDetail(OrderDetail orderDetail)
		{
			_orderDetailRepository.Update(orderDetail);
		}

		public void DeleteDetail(int orderId)
		{
			var orderDetails = GetOrderDetails(orderId);
			foreach (var detail in orderDetails)
				_orderDetailRepository.Delete(detail);
		}

		public void DeleteDetail(int orderId, int displayOrder)
		{
			var orderDetail = _orderDetailRepository.GetSingleByCondition(x => x.OrderId == orderId && x.DisplayOrder == displayOrder);
			_orderDetailRepository.Delete(orderDetail);
		}

		public void DeleteDetail(int productId, int orderId, int colorId, int sizeId)
		{
			var detail = _orderDetailRepository.GetSingleByCondition(x => x.ProductId == productId
		   && x.OrderId == orderId && x.ColorId == colorId && x.SizeId == sizeId);
			_orderDetailRepository.Delete(detail);
		}

		public bool CheckExistDetail(int id, int displayOrder)
		{
			return _orderDetailRepository.CheckContains(x => x.OrderId == id && x.DisplayOrder == displayOrder);

		}
		
		public void Save()
		{
			_unitOfWork.Commit();
		}

	}
}