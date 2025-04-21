
namespace ProjectionOperation
{
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
}
