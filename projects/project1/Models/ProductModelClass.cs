namespace Models
{
	public class ProductModelClass
	{
		public int StoreId { get; set; }
		public int ProductId { get; set; }
		public int CategoryId { get; set; }
		public int DescId { get; set; }
		public int Quantity { get; set; }
		public int Availability { get; set; }
		public string Location { get; set; }
		public double CurrentPrice { get; set; }
		public string CategoryName { get; set; }
		public string CategoryDesc { get; set; }
		public string ProductName { get; set; }
		public string ProductAuthor { get; set; }
		public string ProductIsbn { get; set; }
		public string ProductDesc { get; set; }
		public string ProductAlbum { get; set; }
		public string ProductCompany { get; set; }
		public string ProductVersion { get; set; }
	}
}