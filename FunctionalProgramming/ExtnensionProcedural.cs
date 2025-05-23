﻿namespace FunctionalProgramming
{
	public static class ExtnensionProcedural
	{
		public static IEnumerable<Employee> GetEmployeesWithFirstNameStartsWith(string value)
		{
			var employees = Repository.LoadEmployees();
			foreach (var employee in employees)
			{
				if (employee.FirstName.ToLowerInvariant().StartsWith(value.ToLowerInvariant()))
				{
					// Yielding one employee at a time – efficient for large datasets or lazy evaluation
					yield return employee;

				}
			}
		}
		public static IEnumerable<Employee> GetEmployeesWithFirstNameStartsWithOldWay(string value)
		{
			var employees = Repository.LoadEmployees();
			var res = new List<Employee>();
			foreach (var employee in employees)
			{
				if (employee.FirstName.ToLowerInvariant().StartsWith(value.ToLowerInvariant()))
				{
					res.Add(employee);
				}
			}
			return res;
		}


		public static IEnumerable<Employee> GetEmployeesWithFirstNameEndsWith(string value)
		{
			var employees = Repository.LoadEmployees();
			foreach (var employee in employees)
			{
				if (employee.FirstName.ToLowerInvariant().EndsWith(value.ToLowerInvariant()))
				{
					yield return employee;
				}
			}
		}

		public static IEnumerable<Employee> GetEmployeesWithLastNameStartsWith(string value)
		{
			var employees = Repository.LoadEmployees();
			foreach (var employee in employees)
			{
				if (employee.LastName.ToLowerInvariant().StartsWith(value.ToLowerInvariant()))
				{
					yield return employee;
				}
			}
		}

		public static IEnumerable<Employee> GetEmployeesWithDepartmentEqualsTo(string value)
		{
			var employees = Repository.LoadEmployees();
			foreach (var employee in employees)
			{
				if (employee.Department.ToLowerInvariant() == value.ToLowerInvariant())
				{
					yield return employee;
				}
			}
		}

		public static IEnumerable<Employee> GetEmployeesHiredInYear(int year)
		{
			var employees = Repository.LoadEmployees();
			foreach (var employee in employees)
			{
				if (employee.HireDate.Year == year)
				{
					yield return employee;
				}
			}
		}

		public static IEnumerable<Employee> GetEmployeesByGender(string gender)
		{
			var employees = Repository.LoadEmployees();
			foreach (var employee in employees)
			{
				if (employee.Gender.ToLowerInvariant() == gender.ToLowerInvariant())
				{
					yield return employee;
				}
			}
		}

		public static IEnumerable<Employee> GetEmployeesWithHealthInsuranceValueEqualsTo(bool value)
		{
			var employees = Repository.LoadEmployees();
			foreach (var employee in employees)
			{
				if (employee.HasHealthInsurance == value)
				{
					yield return employee;
				}
			}
		}

		public static IEnumerable<Employee> GetEmployeesWithPensionPlanValueEqualsTo(bool value)
		{
			var employees = Repository.LoadEmployees();
			foreach (var employee in employees)
			{
				if (employee.HasPensionPlan == value)
				{
					yield return employee;
				}
			}
		}

		public static IEnumerable<Employee> GetEmployeesWithSalaryEqualsTo(decimal value)
		{
			var employees = Repository.LoadEmployees();
			foreach (var employee in employees)
			{
				if (employee.Salary == value)
				{
					yield return employee;
				}
			}
		}

		public static IEnumerable<Employee> GetEmployeesWithSalaryGreaterThan(decimal value)
		{
			var employees = Repository.LoadEmployees();
			foreach (var employee in employees)
			{
				if (employee.Salary > value)
				{
					yield return employee;
				}
			}
		}

		public static IEnumerable<Employee> GetEmployeesWithSalaryLessThan(decimal value)
		{
			var employees = Repository.LoadEmployees();
			foreach (var employee in employees)
			{
				if (employee.Salary < value)
				{
					yield return employee;
				}
			}
		}

		public static void Print<T>(IEnumerable<T> source, string title)
		{
			if (source == null)
				return;
			Console.WriteLine();
			Console.WriteLine("┌───────────────────────────────────────────────────────┐");
			Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
			Console.WriteLine("└───────────────────────────────────────────────────────┘");
			Console.WriteLine();
			foreach (var item in source)
				Console.WriteLine(item);
		}

	}
}
