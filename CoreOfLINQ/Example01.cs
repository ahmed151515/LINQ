namespace CoreOfLINQ
{
	public static class Example01
	{
		public static void main()
		{
			var employees = Repository.LoadEmployees();

			var femaleWithSartsSFilter = employees.Filter(e => e.Gender == "female" && e.FirstName.ToLower().StartsWith("s"));
			femaleWithSartsSFilter.Print("female With Sarts S Filter");

			var femaleWithSartsSWhere = employees.Where(e => e.Gender == "female" && e.FirstName.ToLower().StartsWith("s"));
			femaleWithSartsSWhere.Print("female With Sarts S Where");
			var femaleWithSartsSQuery =
				from e in employees where e.Gender == "female" && e.FirstName.ToLower().StartsWith("s") select e;
			femaleWithSartsSQuery.Print("female With Sarts S Query");
		}
	}

}

