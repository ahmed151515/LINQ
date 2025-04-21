
namespace ProjectionOperation
{
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
