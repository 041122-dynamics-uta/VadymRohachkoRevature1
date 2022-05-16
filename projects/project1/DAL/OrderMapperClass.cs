using Models;
using System.Data.SqlClient;

namespace DAL
{
	public class OrderMapperClass
	{
		internal OrderModelClass DboToOrder(SqlDataReader reader)
		{
			OrderModelClass order = new OrderModelClass
			{
				OrderId = (int)reader[0],
				StoreId = (int)reader[2],
				OrderDate = (DateTime)reader[3]
			};
			return order;
		}
	}
}