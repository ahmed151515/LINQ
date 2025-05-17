namespace DataPartitioning
{
	class PaginationExample
	{

		public static void main()
		{
			var employees = Repository.LoadEmployees();

			var p1 = employees.Paginate(2, 30);
			p1.Print(nameof(p1));

			var p2 = employees.Paginate2();
			p2.Print(nameof(p2));





		}
	}
}
