namespace SortingData
{
	public class OrderBy
	{
		public static void main()
		{
			string[] fruits =
				{ "apricot", "orange", "banana", "mango",
				"apple", "grape", "strawberry" };


			var fruitOrederbyAsc = fruits.OrderBy(f => f);
			fruitOrederbyAsc.Print(nameof(fruitOrederbyAsc));

			var fruitOrederbyAscQuerySyntax = from f in fruits orderby f select f;
			fruitOrederbyAscQuerySyntax.Print(nameof(fruitOrederbyAscQuerySyntax));

			var fruitOrederbyDesc = fruits.OrderByDescending(f => f);
			fruitOrederbyDesc.Print(nameof(fruitOrederbyDesc));

			var fruitOrederbyDescQuerySyntax = from f in fruits orderby f descending select f;
			fruitOrederbyDescQuerySyntax.Print(nameof(fruitOrederbyDescQuerySyntax));


			var fruitOrederbyAscLength = fruits.OrderBy(f => f.Length);
			fruitOrederbyAscLength.Print(nameof(fruitOrederbyAscLength));

		}
	}

}
