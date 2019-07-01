using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
		[HttpGet(Url = "/")]
		public IActionResult IndexSlash()
		{
			return Index();
		}

		public IActionResult Index()
		{
			if(this.IsLoggedIn())
			{
				return View("IndexLoggedIn");
			}

			return View();
		}
    }
}