using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.InputModels.Problems;
using SULS.Models;
using SULS.Services;
using SULS.ViewModels.Problems;

namespace SULS.App.Controllers
{
	public class ProblemsController : Controller
	{
		private readonly IProblemsService problemsService;

		public ProblemsController(IProblemsService problemsService)
		{
			this.problemsService = problemsService;
		}

		[Authorize]
		public IActionResult Create()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		public IActionResult Create(ProblemCreateInputModel model)
		{
			if(!ModelState.IsValid)
			{
				return Redirect("/Problems/Create");
			}

			Problem problem = new Problem { Name = model.Name, Points = model.Points };
			problemsService.Create(problem);

			return Redirect("/");
		}

		[Authorize]
		public IActionResult Details(string id)
		{
			ProblemDetailsViewModel model = problemsService.GetProblemDetails(id);
			return View(model);
		}
	}
}
