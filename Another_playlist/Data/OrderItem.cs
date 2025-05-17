

namespace Another_playlist.Data
{
	public class OrderItem
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public string ItemName { get; set; }
		public decimal Price { get; set; }
		public decimal Quntitiy { get; set; }

		public override string ToString()
		{
			return $"Id: {Id}, OrderId: {OrderId}, ItemName: {ItemName}, Price: {Price}, Quantity: {Quntitiy}";
		}
	}
}
