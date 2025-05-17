
namespace Another_playlist.Data
{
	public class Customer
	{
		public int id { get; set; }
		public string name { get; set; }
		public long telephone { get; set; }
		public int age { get; set; }
		public decimal spendAverage { get; set; }
		public int categoryId { get; set; }
		public bool isActive { get; set; }
		public DateTime joinDate { get; set; }

		public override string ToString()
		{
			return $"Id: {id}, Name: {name}, Telephone: {telephone}, Age: {age}, Spend Average: {spendAverage:C}, Category Id: {categoryId}, Active: {isActive}, Join Date: {joinDate:yyyy-MM-dd}\n";
		}
	}
}
