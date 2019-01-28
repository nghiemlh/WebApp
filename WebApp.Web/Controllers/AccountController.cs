using BotDetect.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Common;
using WebApp.Identity;
using WebApp.Model.Models;
using WebApp.Web.Models;

namespace WebApp.Web.Controllers
{
	public class AccountController : Controller
	{
		private ApplicationSignInManager _signInManager;
		private ApplicationUserManager _userManager;

		public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
		{
			UserManager = userManager;
			SignInManager = signInManager;
		}

		public AccountController() { }

		public ApplicationSignInManager SignInManager
		{
			get
			{
				return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
			}
			private set
			{
				_signInManager = value;
			}
		}

		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		// GET: Account
		public ActionResult Login()
		{			
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				AppUser user = _userManager.Find(model.UserName, model.Password);
				if (user != null)
				{
					IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
					authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
					ClaimsIdentity identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
					AuthenticationProperties props = new AuthenticationProperties();
					props.IsPersistent = model.RememberMe;
					authenticationManager.SignIn(props, identity);
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
				}
			}
			return View(model);
		}

		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[CaptchaValidation("CaptchaCode", "registerCaptcha", "Mã xác nhận không đúng")]
		public async Task<ActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				// Check Email is existed
				var userByEmail = await _userManager.FindByEmailAsync(model.Email);
				if (userByEmail != null)
				{
					ModelState.AddModelError("email", "Email đã tồn tại");
					return View(model);
				}

				// Check Username is existed
				var userByUserName = await _userManager.FindByNameAsync(model.UserName);
				if (userByUserName != null)
				{
					ModelState.AddModelError("email", "Tài khoản đã tồn tại");
					return View(model);
				}

				var user = new AppUser()
				{
					UserName = model.UserName,
					Email = model.Email,
					EmailConfirmed = true,
					BirthDay = model.BirthDay,
					FullName = model.FullName,
					PhoneNumber = model.PhoneNumber,
					Address = model.Address
				};

				await _userManager.CreateAsync(user, model.Password);
				var adminUser = await _userManager.FindByEmailAsync(model.Email);
				if (adminUser != null)
					await _userManager.AddToRolesAsync(adminUser.Id, new string[] { "User" });

				string content = System.IO.File.ReadAllText(Server.MapPath("/Dist/template/newuser.html"));
				content = content.Replace("{{UserName}}", adminUser.FullName);
				content = content.Replace("{{Link}}", ConfigHelper.GetByKey("CurrentLink") + "login.html");
				MailHelper.SendMail(adminUser.Email, "Đăng ký thành công", content);
				ViewData["SuccessMsg"] = "Đăng ký thành công";
			}
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOut()
		{
			IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
			authenticationManager.SignOut();
			return RedirectToAction("Index", "Home");
		}
	}
}