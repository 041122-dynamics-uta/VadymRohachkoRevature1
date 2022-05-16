using System;
using Models;
using System.Data.SqlClient; //dotnet add package System.Data.SqlClient --version 4.8.3

namespace DAL;
public class DALClass
{
	public CustomerMapperClass _mapper { get; set; }
	public LogMapperClass _log { get; set; }
	public StoreLocationMapperClass _location { get; set; }
	public CategoryMapperClass _category { get; set; }

	string connectionString = $"Server = tcp:vadymrohachkoserver.database.windows.net,1433; Initial Catalog = OnlineStore1; Persist Security Info = False; User ID = VadymRohachkoDB; Password = 123; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

	public DALClass()
	{
		this._mapper = new CustomerMapperClass();
		this._log = new LogMapperClass();
		this._location = new StoreLocationMapperClass();
		this._category = new CategoryMapperClass();
	}

	public List<CategoryModelClass> GetCategory()
	{
		List<CategoryModelClass> categories = new List<CategoryModelClass>();
		string myQuery1 = "SELECT * FROM Categories;";

		using (SqlConnection query1 = new SqlConnection(connectionString))
		{
			SqlCommand command = new SqlCommand(myQuery1, query1);
			command.Connection.Open();
			SqlDataReader results = command.ExecuteReader();

			while (results.Read())
			{
				categories.Add(this._category.DboToCategory(results));
			}
			query1.Close();
			return categories;
		}
	}

	public List<StoreLocationModelClass> GetStoreLocation()
	{
		List<StoreLocationModelClass> storeLocation = new List<StoreLocationModelClass>();
		string myQuery1 = "SELECT * FROM Stores;";

		using (SqlConnection query1 = new SqlConnection(connectionString))
		{
			SqlCommand command = new SqlCommand(myQuery1, query1);
			command.Connection.Open();
			SqlDataReader results = command.ExecuteReader();

			while (results.Read())
			{
				storeLocation.Add(this._location.DboToStoreLocation(results));
			}
			query1.Close();
			return storeLocation;
		}
	}

	public List<LogModelClass> GetLog(int id)
	{
		string myQuery1 = "Select logDate, name from Logs JOIN Actions ON Actions.actionId = Logs.actionId where customerId = @customerId";

		using (SqlConnection query1 = new SqlConnection(connectionString))
		{
			SqlCommand command = new SqlCommand(myQuery1, query1);
			command.Parameters.AddWithValue("@customerId", id);
			command.Connection.Open();
			SqlDataReader results = command.ExecuteReader();

			List<LogModelClass> log = new List<LogModelClass>();
			while (results.Read())
			{
				log.Add(this._log.DboToLog(results));
			}

			query1.Close();
			return log;
		}

		return new List<LogModelClass>();
	}

	public List<CustomerModelClass> Login(CustomerModelClass user)
	{
		const int actionId = 7;
		List<CustomerModelClass> cust = new List<CustomerModelClass>();
		string myQuery1 = "SELECT * FROM Customers where  email = @email and password = @password";
		string myQuery2 = "Insert into Logs (customerId, actionId) Values(@customerId, @actionId);";

		using (SqlConnection query1 = new SqlConnection(connectionString))
		{
			SqlCommand command = new SqlCommand(myQuery1, query1);
			command.Parameters.AddWithValue("@email", user.email);
			command.Parameters.AddWithValue("@password", user.password);
			command.Connection.Open();
			SqlDataReader results = command.ExecuteReader();

			while (results.Read())
			{
				cust.Add(this._mapper.DboToCustomer(results));
			}
			query1.Close();
		}

		using (SqlConnection query2 = new SqlConnection(connectionString))
		{
			SqlCommand command = new SqlCommand(myQuery2, query2);
			command.Parameters.AddWithValue("@customerId", cust[0].customerId);
			command.Parameters.AddWithValue("@actionId", actionId);
			command.Connection.Open();
			command.ExecuteNonQuery();
			query2.Close();
		}

		return cust;
	}

	public List<CustomerModelClass> Register(CustomerModelClass user)
	{
		const int actionId = 8;
		string myQuery1 = "INSERT INTO Customers (lastName, firstName, email, password) VALUES(@lastName, @firstName, @email, @password);";
		string myQuery2 = "SELECT * FROM Customers where  email = @email and password = @password and lastName = @lastName and firstName = @firstName;";
		string myQuery3 = "Insert into Logs (customerId, actionId) Values(@customerId, @actionId);";

		List<CustomerModelClass> cust = new List<CustomerModelClass>();

		try
		{
			using (SqlConnection query1 = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(myQuery1, query1);
				command.Parameters.AddWithValue("@email", user.email);
				command.Parameters.AddWithValue("@password", user.password);
				command.Parameters.AddWithValue("@firstName", user.firstName);
				command.Parameters.AddWithValue("@lastName", user.lastName);
				command.Connection.Open();
				SqlDataReader results = command.ExecuteReader();

				query1.Close();
			}

			using (SqlConnection query1 = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(myQuery2, query1);
				command.Parameters.AddWithValue("@email", user.email);
				command.Parameters.AddWithValue("@password", user.password);
				command.Parameters.AddWithValue("@firstName", user.firstName);
				command.Parameters.AddWithValue("@lastName", user.lastName);
				command.Connection.Open();
				SqlDataReader results = command.ExecuteReader();

				while (results.Read())
				{
					cust.Add(this._mapper.DboToCustomer(results));
				}

				query1.Close();
			}

			using (SqlConnection query1 = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(myQuery3, query1);
				command.Parameters.AddWithValue("@customerId", cust[0].customerId);
				command.Parameters.AddWithValue("@actionId", actionId);
				command.Connection.Open();
				command.ExecuteNonQuery();
				query1.Close();
			}

			return cust;
		}
		catch (System.Exception)
		{
			return new List<CustomerModelClass>();
		}

	}
}
