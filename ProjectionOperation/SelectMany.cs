
namespace ProjectionOperation
{
	public static class SelectMany
	{
		/*
		 * SELECTMANY
		 * Projects sequences of values then flattens them into one sequence
		 */
		public static void main()
		{
			//Example01();
			Example02();
		}

		private static void Example01()
		{
			string[] sentences = {
				"I love asp.net core",
				"I like sql server also",
				"in general i love programming"
			};

			var sentencesToOneArray = sentences.SelectMany(s => s.Split(' '));

			sentencesToOneArray.Print(nameof(sentencesToOneArray));


		}
		private static void Example02()
		{
			var employees = Repository.LoadEmployees();

			var AllSkills = employees.SelectMany(e => e.Skills);

			AllSkills.Print(nameof(AllSkills));

			var AllSkillsQureySyntax = from e in employees from s in e.Skills select s;

			AllSkillsQureySyntax.Print(nameof(AllSkillsQureySyntax));

			var AllSkillsDistinct = AllSkills.Distinct();

			AllSkillsDistinct.Print(nameof(AllSkillsDistinct));

			var AllSkillsQureySyntaxDistinct = (from e in employees from s in e.Skills select s).Distinct();

			AllSkillsQureySyntaxDistinct.Print(nameof(AllSkillsQureySyntaxDistinct));

		}
	}
}
