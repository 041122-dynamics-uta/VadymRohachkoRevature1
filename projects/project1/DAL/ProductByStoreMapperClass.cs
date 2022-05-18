using Models;
using System.Data.SqlClient;

namespace DAL
{
	public class ProductByStoreMapperClass
	{
		internal ProductByStoreModelClass DboToProductByStore(SqlDataReader reader)
		{
			ProductByStoreModelClass productByStore = new ProductByStoreModelClass
			{
				ProductId = (int)reader[0],
				CategoryId = (int)reader[1],
				CurrentPrice = (double)reader[2],
				TotalQuantity = (int)reader[3],
				//DescId = (int)reader[4],
				StoreId = (int)reader[4],
				////ProductId = (int)reader[5],
				Quantity = (int)reader[5],
				Availability = (int)reader[8],
				Location = (string)reader[6],
				// //LastUpdateDate = (DateTime)reader[10],
				Name = (string)reader[7],
				Author = (string)reader[8],
				ISBN = (string)reader[9],
				Description = (string)reader[10],
				Album = (string)reader[11],
				Company = (string)reader[12],
				Vesrsion = (string)reader[13]
			};
			return productByStore;
		}
	}
}