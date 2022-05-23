using Models;
using System.Data.SqlClient;

namespace DAL
{
	public class CartMapperClass
	{
		internal CartModelClass DboToCart(SqlDataReader reader)
		{
			CartModelClass cart = new CartModelClass
			{
				CartId = (Guid)reader[0],
				CustomerId = (int)reader[2]
			};
			return cart;
		}
	}
}