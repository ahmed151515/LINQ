namespace SortingData
{
	public class ThenBy
	{
		public static void main()
		{
			var employees = Repository.LoadEmployees();

			var employeesOrderbyNameAndSalary = employees.OrderBy(e => e.Name)
				.ThenBy(e => e.Salary);

			var employeesOrderbyNameAndSalaryQuerySyntax = from e in employees
														   orderby e.Name, e.Salary
														   select e;
			employeesOrderbyNameAndSalaryQuerySyntax.Print(nameof(employeesOrderbyNameAndSalaryQuerySyntax));
			employeesOrderbyNameAndSalary.Print(nameof(employeesOrderbyNameAndSalary));

			// e.EmployeeNo = "2017-FI-1343" the first section is entry year 
			var employeesOrderbyEntryYear = employees.OrderBy(e => e.EmployeeNo[0..4]);
			employeesOrderbyEntryYear.Print(nameof(employeesOrderbyEntryYear));
		}
	}

}
