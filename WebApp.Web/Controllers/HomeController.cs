using AutoMapper;
using System.Web.Mvc;
using WebApp.Model.Models;
using WebApp.Service;
using WebApp.Web.Models;

namespace WebApp.Web.Controllers
{
	public class HomeController : Controller
	{
		private IProductCategoryService _productCategoryService;
		private IProductService _productService;
		private ICommonService _commonService;
		private IPageService _pageService;

		public HomeController(IProductCategoryService productCategoryService, IProductService productService, ICommonService commonService, IPageService pageService)
		{
			_productCategoryService = productCategoryService;
			_productService = productService;
			_commonService = commonService;
			_pageService = pageService;
		}

		[OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Client)]
		public ActionResult Index()
		{
			var homeViewModel = new HomeViewModel();
			homeViewModel.Title = "Trang chủ";
			homeViewModel.MetaKeyword = "Trang chủ WebApp";
			homeViewModel.MetaDescription = "Trang chủ WebApp Life";

			var pageViewModel = _pageService.GetByAlias("gioi-thieu");
			homeViewModel.Pages = Mapper.Map<Page, PageViewModel>(pageViewModel);

			return View(homeViewModel);
			//return Redirect("/Help");
		}

		[ChildActionOnly] // Chỉ định chỉ được nhúng vào trang Home
		public ActionResult Header()
		{
			//var model = _productCategoryService.GetAll();
			//var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
			return PartialView(); // Nếu tên của View khác tên phương thức thì return PartialView("NameView");
		}

		[ChildActionOnly] // Chỉ định chỉ được nhúng vào trang Home
		[OutputCache(Duration = 3600)]
		public ActionResult Footer()
		{
			//var footerModel = _commonService.GetFooter();
			//var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
			return PartialView(); // Nếu tên của View khác tên phương thức thì return PartialView("NameView");
		}
	}
}