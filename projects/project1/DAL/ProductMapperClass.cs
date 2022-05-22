using Models;
using System.Data.SqlClient;

namespace DAL
{
	public class ProductMapperClass
	{
		internal ProductModelClass DboToProduct(SqlDataReader reader)
		{
			ProductModelClass product = new ProductModelClass
			{
				StoreId = (int)reader[0],
				ProductId = (int)reader[1],
				CategoryId = (int)reader[2],
				DescId = (int)reader[3],
				Quantity = (int)reader[4],
				Availability = (int)reader[5],
				Location = (string)reader[6],
				CurrentPrice = (double)reader[7],
				CategoryName = (string)reader[8],
				CategoryDesc = (string)reader[9],
				ProductName = (string)reader[10],
				ProductAuthor = (string)reader[11],
				ProductIsbn = (string)reader[12],
				ProductDesc = (string)reader[13],
				ProductAlbum = (string)reader[14],
				ProductCompany = (string)reader[15],
				ProductVersion = (string)reader[16]
			};
			return product;
		}
	}
}
