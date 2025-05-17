namespace DataPartitioning
{
	class Chunck
	{
		//  Available in net6.0 above
		public static void main()
		{
			var employees = Repository.LoadEmployees();


			var chunks = employees.Chunk(10);
			int i = 1;
			foreach (var item in chunks)
			{

				item.Print($"chunk {i}");
				i++;
			}

		}
	}
}
