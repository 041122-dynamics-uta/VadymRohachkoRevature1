namespace Models
{
	public class ProductByStoreModelClass
	{
		public int ProductId { get; set; }
		public int CategoryId { get; set; }
		public double CurrentPrice { get; set; }
		public int TotalQuantity { get; set; }
		////public int DescId { get; set; }
		public int StoreId { get; set; }
		/// <summary>
		/// /public int ProductId { get; set; }
		/// </summary>
		public int Quantity { get; set; }
		public int Availability { get; set; }
		public string Location { get; set; }
		// //public DateTime LastUpdateDate { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public string ISBN { get; set; }
		public string Description { get; set; }
		public string Album { get; set; }
		public string Company { get; set; }
		public string Vesrsion { get; set; }

	}
}

