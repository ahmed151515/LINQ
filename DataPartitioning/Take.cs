namespace DataPartitioning
{
	class Take
	{
		/*
		 * Take
		 * TakeWhile
		 * TakeLast
		 */
		public static void main()
		{
			var employees = Repository.LoadEmployees();

			var empsTakeFirst10 = employees.Take(10);
			empsTakeFirst10.Print(nameof(empsTakeFirst10));

			var empsTakeWhileIndexNot20 = employees.TakeWhile(e => e.Index != 20);
			empsTakeWhileIndexNot20.Print(nameof(empsTakeWhileIndexNot20));

			var empsTakeLast10 = employees.TakeLast(10);
			empsTakeLast10.Print(nameof(empsTakeLast10));

		}
	}
}
