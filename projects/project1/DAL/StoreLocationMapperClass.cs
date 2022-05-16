using Models;
using System.Data.SqlClient;

namespace DAL
{
	public class StoreLocationMapperClass
	{
		internal StoreLocationModelClass DboToStoreLocation(SqlDataReader reader)
		{
			StoreLocationModelClass storeLocation = new StoreLocationModelClass
			{
				StoreId = (int)reader[0],
				Location = (string)reader[4]
			};
			return storeLocation;
		}
	}
}