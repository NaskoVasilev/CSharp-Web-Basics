﻿using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.Services;
using SULS.ViewModels.Home;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
		private readonly IProblemsService problemsService;

		public HomeController(IProblemsService problemsService)
		{
			this.problemsService = problemsService;
		}

		[HttpGet(Url = "/")]
		public IActionResult IndexSlash()
		{
			return Index();
		}

		public IActionResult Index()
		{
			if(this.IsLoggedIn())
			{
				var problems = problemsService.All();
				return View(new HomeViewModel() { Problems = problems } ,"IndexLoggedIn");
			}

			return View();
		}
    }
}