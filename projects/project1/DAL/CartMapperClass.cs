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
				ProductId = (int)reader[1],
				Quantity = (int)reader[2],
				CurrentPrice = (double)reader[3],
				ProductName = (string)reader[4],
				ProductAuthor = (string)reader[5],
				Total = (double)reader[6],
				StoreId = (int)reader[7]
			};
			return cart;
		}
	}
}

// SELECT Carts.cartid, Products.productId, Customers.customerId, Stores.storeId, Categories.categoryId, Products.descId,
// Stores.quantity, Products.currentPrice, ProductDescs.name, ProductDescs.author FROM Carts
// JOIN Customers
// ON Customers.customerId = Carts.customerId
// JOIN Stores
// ON Stores.storeId = Carts.storeId
// JOIN Products
// ON Products.productId = Stores.productId
// JOIN Categories
// ON Categories.categoryId = Products.categoryId
// JOIN ProductDescs
// ON ProductDescs.descId = Products.descId