namespace FunctionalProgramming
{
	public class Delegate
	{

		public static void main()
		{
			M2(M1);

			M3((x, y) => x + y);
		}

		public static void M1()
		{
			Console.WriteLine("Method 1");
		}
		public static void M2(Action fun)
		{
			fun();
		}
		public static void M3(Func<int, int, int> fun)
		{
			int a = 4, b = 5;
			Console.WriteLine(fun(a, b));
		}
	}
}
