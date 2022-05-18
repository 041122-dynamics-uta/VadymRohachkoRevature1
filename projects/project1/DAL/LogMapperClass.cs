using Models;
using System.Data.SqlClient;

namespace DAL
{
	public class LogMapperClass
	{
		internal LogModelClass DboToLog(SqlDataReader reader)
		{
			LogModelClass log = new LogModelClass
			{
				DateTime = (DateTime)reader[0],
				ActionName = (string)reader[1]
			};
			return log;
		}

	}
}