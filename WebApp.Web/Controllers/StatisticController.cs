using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Service;
using WebApp.Web.Infrastructure.Core;

namespace WebApp.Web.Controllers
{
    [RoutePrefix("api/statistic")]
    public class StatisticController : ApiControllerBase
    {
        private IStatisticService _statisticService;

        public StatisticController(IErrorService errorService, IStatisticService statisticService) : base(errorService)
        {
            _statisticService = statisticService;
        }

        [Route("getrevenue")]
        [HttpGet]
        public HttpResponseMessage GetRevenueStatistic(HttpRequestMessage request, string fromDate, string toDate)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _statisticService.GetRevenueStatistic(fromDate, toDate);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }

		[Route("getrevenue")]
		[HttpGet]
		public HttpResponseMessage GetRevenueStatistic(HttpRequestMessage request, string fromDate, string toDate, int? productId, int? colorId, int? sizeId)
		{
			return CreateHttpResponse(request, () =>
			{
				var model = _statisticService.GetRevenueStatistic(fromDate, toDate);
				HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);
				return response;
			});
		}
	}
}