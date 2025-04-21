
namespace ProjectionOperation
{
	internal class Program
	{

		/*
		 * Projection is the process of converting an object into a new form,
		 * typically to select specific properties or to shape the data for further use.
		 * Constructing a new type (Data transfer object)
		 * Projecting a new property
		 * Performing a mathematical operation
		 * 
		 * select
		 * selectMany
		 * zip
		 */

		static void Main(string[] args)
		{
			//Select.main();
			//SelectMany.main();
			Zip.main();
		}
	}
	public static class Select
	{
		public static void main()
		{
			//Example01();
			//Example02();
			Example03();

		}

		private static void Example01()
		{

			// Projecting a new property
			List<string> words = new() { "i", "love", "asp.net", "core" };

			var wordsToUpper = words.Select(x => x.ToUpper());
			var wordsToUpperQureySyntax = from w in words select w.ToUpper();


			wordsToUpper.Print(nameof(wordsToUpper));
			wordsToUpperQureySyntax.Print(nameof(wordsToUpperQureySyntax));

			var wordsReplaceOTo0 = words.Select(x => x.Replace('o', '0'));

			wordsReplaceOTo0.Print(nameof(wordsReplaceOTo0));
		}
		private static void Example02()
		{
			// mathematical operation
			List<int> numbers = new() { 2, 3, 5, 7 };

			var numProduct2 = numbers.Select(n => n * 2);

			numProduct2.Print(nameof(numProduct2));


			var numProduct2QureySyntax = from n in numbers select n * 2;

			numProduct2QureySyntax.Print(nameof(numProduct2QureySyntax));

		}
		class EmployeeDTO
		{
			public string Name { get; set; }
			public int TotalSkills { get; set; }

			public override string ToString()
			{
				return
					$"Name = {Name} | TotalSkills = {TotalSkills}";
			}
		}
		private static void Example03()
		{
			// Constructing a new type

			var employees = Repository.LoadEmployees();

			var employeeToDto = employees.Select(e => new EmployeeDTO
			{
				Name = $"{e.FirstName} {e.LastName}",
				TotalSkills = e.Skills.Count
			});

			employeeToDto.Print(nameof(employeeToDto));

		}

	}
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
	public static class Zip
	{/*
	  * Zip: 
	  * Produces a sequence of tuples with elements from 2-3 specified sequence
	  */
		public static void main()
		{
			//Example01();
			Example02();
		}

		private static void Example01()
		{
			string[] colorName = { "Red", "Green", "Blue" };
			string[] colorHEX = { "FF0000", "00FF00", "0000FF", "extra" };

			var colors = colorName.Zip(colorHEX, (name, hex) => $"{name}: {hex}");

			colors.Print(nameof(colors));

		}
		private static void Example02()
		{
			var employees = Repository.LoadEmployees().ToArray();

			var firstThreeEmp = employees[..3];
			var lastThreeEmp = employees[^3..];

			var teams = firstThreeEmp.Zip(lastThreeEmp, (f, s) => $"{f.FirstName} with {s.FirstName}");

			teams.Print(nameof(teams));

			var teamsQureySyntax = from team in firstThreeEmp.Zip(lastThreeEmp)
								   select $"{team.First.FirstName} with {team.Second.FirstName}";

			teamsQureySyntax.Print(nameof(teamsQureySyntax));


		}
	}
}
