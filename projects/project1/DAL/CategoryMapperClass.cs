using Models;
using System.Data.SqlClient;

namespace DAL
{
	public class CategoryMapperClass
	{
		internal CategoryModelClass DboToCategory(SqlDataReader reader)
		{
			CategoryModelClass category = new CategoryModelClass
			{
				CategoryId = (int)reader[0],
				Name = (string)reader[1],
				Description = (string)reader[2]
			};
			return category;
		}
	}
}