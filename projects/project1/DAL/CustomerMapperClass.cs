using Models;
using System.Data.SqlClient;

namespace DAL
{
	public class CustomerMapperClass
	{
		internal CustomerModelClass DboToCustomer(SqlDataReader reader)
		{
			CustomerModelClass cust = new CustomerModelClass
			{
				customerId = (int)reader[0],
				lastName = (string)reader[1],
				firstName = (string)reader[2]
			};
			return cust;
		}
	}
}