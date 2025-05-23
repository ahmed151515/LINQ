namespace LINQAnatomy
{
	public static class Extensions
	{
		public static void PrintDeck(this IEnumerable<Card> cards, string title)
		{
			Console.WriteLine($"\n\n\n###### {title} ######");
			foreach (Card card in cards)
			{
				Console.WriteLine(card.Name);
			}
		}
		public static void Print<T>(this IEnumerable<T> values)
		{

			foreach (var value in values)
			{
				Console.WriteLine(value);
			}
		}
	}
}
