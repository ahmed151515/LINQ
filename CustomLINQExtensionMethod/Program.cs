namespace CustomLINQExtensionMethod
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var employees = Repository.Employees;


			var empsPaginantePage1And10items = employees.Paginante();

			empsPaginantePage1And10items.Print(nameof(empsPaginantePage1And10items));


			var empsPaginantePage1And10itemsAndHasHasHealthInsurance = employees.Paginante(e => e.HasHealthInsurance);

			empsPaginantePage1And10itemsAndHasHasHealthInsurance.Print(nameof(empsPaginantePage1And10itemsAndHasHasHealthInsurance));
		}
	}
}
