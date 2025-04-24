namespace SortingData
{
	public class OrderByCustom
	{
		public static void main()
		{
			IEnumerable<Employee> emps = Repository.LoadEmployees();
			//IOrderedEnumerable<Employee> sortedEmps = 
			//    emps.OrderBy(e => e.EmployeeNo);


			IOrderedEnumerable<Employee> sortedEmps =
			 emps.OrderBy(e => e, new EmployeeComparer());
			sortedEmps.Print("sorted employees");

			// Query Syntax not have Custom Comparer (IComparer) 
			// If the data is large, using custom comparers in sorting operations could negatively affect performance 
		}
	}

}
