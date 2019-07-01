﻿using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.InputModels.Users;
using SULS.Models;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class UsersController : Controller
    {
		private readonly IUsersService usersService;

		public UsersController(IUsersService usersService)
		{
			this.usersService = usersService;
		}

		public IActionResult Login()
		{
			return this.View();
		}

		[HttpPost]
		public IActionResult Login(LoginInputModel model)
		{
			User user = usersService.GetUserOrNull(model.Username, model.Password);
			if (user == null)
			{
				ModelState.Add("Username", "Invalid username or password!");
				return Redirect("/Users/Login");
			}

			this.SignIn(user.Id, user.Username, user.Email);
			return Redirect("/");
		}

		public IActionResult Register()
		{
			return this.View();
		}

		[HttpPost]
		public IActionResult Register(RegisterInputModel model)
		{
			if (!ModelState.IsValid)
			{
				return Redirect("/Users/Register");
			}

			if (model.Password != model.ConfirmPassword)
			{
				ModelState.Add(string.Empty, "The passwords must match");
				return Redirect("/Users/Register");
			}

			if (usersService.UserExists(model.Username))
			{
				ModelState.Add(string.Empty, "User with the same username already exists!");
				return Redirect("/Users/Register");
			}

			User user = new User
			{
				Email = model.Email,
				Username = model.Username,
				Password = model.Password
			};

			string userId = usersService.CreateUser(user);
			this.SignIn(userId, model.Username, model.Email);

			return Redirect("/");
		}

		public IActionResult Logout()
		{
			this.SignOut();
			return Redirect("/");
		}
	}
}