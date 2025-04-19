namespace FunctionalProgramming
{
	public class ExtensionFunctional01
	{
		// it is high order funcion (function take(argrumnt) or return function ) Almost all functions of LINQ it is  high order funcion
		public static IEnumerable<Employee> Filter(IEnumerable<Employee> employees, Predicate<Employee> predicate)
		{
			foreach (var item in employees)
			{
				if (predicate(item))
				{
					yield return item;
				}
			}
		}
	}
}
