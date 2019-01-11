using System.Collections.Generic;
using WebApp.Common.ViewModels;
using WebApp.Data.Repositories;

namespace WebApp.Service
{
	public interface IStatisticService
	{
		IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);
	}

	public class StatisticService : IStatisticService
	{
		private IOrderRepository _orderRepository;

		public StatisticService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
		{
			return _orderRepository.GetRevenueStatistic(fromDate, toDate);
		}
	}
}