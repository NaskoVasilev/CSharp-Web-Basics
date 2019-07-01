using SIS.MvcFramework.Attributes.Validation;

namespace SULS.InputModels.Submissions
{
	public class SubmissionCreateInputModel
	{
		private const string CodeErrorMessage = "Code must be between 30 and 800 symbols.";

		public string ProblemId { get; set; }

		[RequiredSis]
		[StringLengthSis(30, 800, CodeErrorMessage)]
		public string Code { get; set; }
	}
}