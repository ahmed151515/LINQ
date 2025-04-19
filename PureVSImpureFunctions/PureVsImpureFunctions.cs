namespace PureVSImpureFunctions
{

	namespace PureVsImpureFunctions
	{
		class PureVsImpureFunctions
		{
			static List<int> ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			public static void main()
			{
				Print(ints);

				AddInteger1(10);

				Print(ints);

				int n = 10;
				AddInteger2(ref n);
				Console.WriteLine($"-{n}-");
				Print(ints);
				AddInteger3();

				Print(ints);
				Print(AddInteger4(ints, 12));


			}

			static void Print(IList<int> ints)
			{
				foreach (var item in ints)
				{
					Console.Write($"{item} ");
				}
				Console.WriteLine();
			}
			static void AddInteger1(int num)
			{
				ints.Add(num); // impure  mutate global varible (side effect) The effect if you use it elsewhere
			}
			static void AddInteger2(ref int num)
			{
				num++;// impure mutate parameter 
				ints.Add(num);
			}
			static void AddInteger3()
			{

				ints.Add(new Random().Next()); // impure interation whit outside world
			}
			static List<int> AddInteger4(List<int> ints, int num)
			{
				var res = new List<int>(ints);
				res.Add(num);
				return res;

			}

		}
	}
}
