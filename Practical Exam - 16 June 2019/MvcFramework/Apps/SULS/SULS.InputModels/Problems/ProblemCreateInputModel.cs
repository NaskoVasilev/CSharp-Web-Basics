using SIS.MvcFramework.Attributes.Validation;

namespace SULS.InputModels.Problems
{
	public class ProblemCreateInputModel
	{
		private const string PointsErrorMessage = "Total points must be between 50 and 300";
		private const string NameErrorMessage = "Name must be between 5 and 20 symbols";

		[RequiredSis]
		[StringLengthSis(5, 20, NameErrorMessage)]
		public string Name { get; set; }

		[RangeSis(50, 300, PointsErrorMessage)]
		public int Points { get; set; }
	}
}
