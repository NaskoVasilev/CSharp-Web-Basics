using SIS.MvcFramework.Attributes.Validation;

namespace SULS.InputModels.Users
{
	public class RegisterInputModel
	{
		private const string UsernameErrorMessage = "Username must between 5 and 20 symbols.";
		private const string PasswordErrorMessage = "Password must between 6 and 20 symbols.";

		[RequiredSis]
		[StringLengthSis(5, 20, UsernameErrorMessage)]
		public string Username { get; set; }

		[RequiredSis]
		[StringLengthSis(6, 20, PasswordErrorMessage)]
		public string Password { get; set; }

		public string ConfirmPassword { get; set; }

		[RequiredSis]
		[EmailSis]
		public string Email { get; set; }
	}
}
