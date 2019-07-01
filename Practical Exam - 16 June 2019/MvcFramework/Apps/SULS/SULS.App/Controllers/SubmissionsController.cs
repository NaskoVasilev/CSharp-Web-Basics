using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.InputModels.Submissions;
using SULS.Models;
using SULS.Services;
using SULS.ViewModels.Problems;

namespace SULS.App.Controllers
{
	public class SubmissionsController : Controller
	{
		private readonly ISubmissionsService submissionsService;
		private readonly IProblemsService problemsService;

		public SubmissionsController(ISubmissionsService submissionsService, IProblemsService problemsService)
		{
			this.submissionsService = submissionsService;
			this.problemsService = problemsService;
		}

		[Authorize]
		public IActionResult Create(string id)
		{
			ProblemSubmissionViewModel model = problemsService.GetProblemInfo(id);
			return View(model);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Create(SubmissionCreateInputModel model)
		{
			if(!ModelState.IsValid)
			{
				return Redirect("/Submissions/Create?id=" + model.ProblemId);
			}

			Submission submission = new Submission
			{
				Code = model.Code,
				ProblemId = model.ProblemId,
				UserId = this.User.Id,
			};

			submissionsService.Create(submission);

			return Redirect("/");
		}

		[Authorize]
		public IActionResult Delete(string id)
		{
			submissionsService.Delete(id);
			return Redirect("/");
		}
	}
}
