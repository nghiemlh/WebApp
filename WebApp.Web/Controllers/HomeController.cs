using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApp.Model.Models;
using WebApp.Service;
using WebApp.Web.App_Start;
using WebApp.Web.Models;

namespace WebApp.Web.Controllers
{
	public class HomeController : Controller
	{
		private IProductCategoryService _productCategoryService;
		private IProductService _productService;
		private IObjectCategoryService _objectCategoryService;
		private IObjectService _objectService;
		private ISlideService _slideService;
		private IPageService _pageService;

		public HomeController(
			IProductCategoryService productCategoryService,
			IProductService productService,
			ISlideService slideService,
			IPageService pageService,
			IObjectService objectService,
			IObjectCategoryService objectCategoryService,
			ApplicationUserManager userManager,
			ApplicationSignInManager signInManager)
		{
			_productCategoryService = productCategoryService;
			_productService = productService;
			_objectCategoryService = objectCategoryService;
			_objectService = objectService;
			_slideService = slideService;
			_pageService = pageService;
		}

		[OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Client)]
		public ActionResult Index()
		{
			var homeViewModel = new HomeViewModel();
			homeViewModel.Title = "Trang chủ";
			homeViewModel.MetaKeyword = "Trang chủ WebApp";
			homeViewModel.MetaDescription = "Trang chủ WebApp Life";

			// Slide
			var slideViewModel = _slideService.GetAll("");
			homeViewModel.Slides = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideViewModel);

			// Page introduction
			var pageViewModel = _pageService.GetByAlias("gioi-thieu");
			homeViewModel.Pages = Mapper.Map<Page, PageViewModel>(pageViewModel);

			// Service
			var serviceViewModel = _productService.GetLastest(6, 39);
			homeViewModel.Services = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(serviceViewModel);

			// Team
			var teamViewModel = _objectCategoryService.GetAllByParentId(4);
			homeViewModel.Teams = Mapper.Map<IEnumerable<ObjectCategory>, IEnumerable<ObjectCategoryViewModel>>(teamViewModel);

			// Product
			var productViewModel = _productService.GetLastest(8, 41);
			homeViewModel.LastestProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productViewModel);

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