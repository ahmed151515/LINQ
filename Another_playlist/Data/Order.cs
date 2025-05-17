

namespace Another_playlist.Data
{
	public class Order
	{
		public int Id { get; set; }
		public decimal total { get; set; }
		public DateTime orderDate { get; set; }
		public int customerId { get; set; }

		public override string ToString()
		{
			return $"Order Id: {Id}, Total: {total:C}, Order Date: {orderDate:yyyy-MM-dd}, Customer Id: {customerId}";
		}

	}
}
