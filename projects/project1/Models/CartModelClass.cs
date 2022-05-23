namespace Models
{
	public class CartModelClass
	{
		public Guid CartId { get; set; }
		public int ProductId { get; set; }
		public int CustomerId { get; set; }
		public int Quantity { get; set; }
		public int StoreId { get; set; }
		public int CategoryId { get; set; }
		public int DescId { get; set; }
		public double CurrentPrice { get; set; }
		public string ProductName { get; set; }
		public string ProductAuthor { get; set; }
		public double Total { get; set; }

	}
}