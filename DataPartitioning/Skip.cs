namespace DataPartitioning
{
	class Skip
	{
		/*
		 * Skip
		 * SkipWhile
		 * SkipLast
		 */

		public static void main()
		{
			var employees = Repository.LoadEmployees();

			var empsSkipFirst10 = employees.Skip(10);
			empsSkipFirst10.Print(nameof(empsSkipFirst10));

			var empsSkipWhileIndexNot20 = employees.SkipWhile(e => e.Index != 20);
			empsSkipWhileIndexNot20.Print(nameof(empsSkipWhileIndexNot20));

			var empsSkipLast10 = employees.SkipLast(10);
			empsSkipLast10.Print(nameof(empsSkipLast10));

		}



	}
}
