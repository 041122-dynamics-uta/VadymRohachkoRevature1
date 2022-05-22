namespace DAL
{
	public class ProductMapperClass
	{
		internal ProductModelClass DboToProduct(SqlDataReader reader)
		{
			ProductModelClass product = new ProductModelClass
			{
				ProductId = (int)reader[0],
				StoreId = (int)reader[1],
				CategoryId = (int)reader[2],
				DescId = (int)reader[3],
				CurrentPrice = (decimal)reader[4],
				LocalQuantity = (int)reader[5],
				CategoryName = (string)reader[6],
				CategoryDesc = (string)reader[7],
				ProductName = (string)reader[8],
				ProductAuthor = (string)reader[9],
				ProductDesc = (string)reader[10],
				ProductAlbum = (string)reader[11],
				ProductVersion = (string)reader[12],
				ProductAuthor = (string)reader[13],
				ProductIsbn = (string)reader[14]
			};
			return product;
		}
	}
}
