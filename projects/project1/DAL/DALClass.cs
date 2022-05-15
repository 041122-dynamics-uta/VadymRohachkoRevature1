using System;
using Models;
using System.Data.SqlClient; //dotnet add package System.Data.SqlClient --version 4.8.3

// using System.Data.SqlClient.SqlConnection;
// using System.Data.SqlClient.SqlException;
// using System.Data.SqlClient.SqlParameter;
// using System.Data.SqlDbType;
// using System.Data.SqlClient.SqlDataReader;
// using System.Data.SqlClient.SqlCommand;
// using System.Data.SqlClient.SqlTransaction;
// using System.Data.SqlClient.SqlParameterCollection;
// using System.Data.SqlClient.SqlClientFactory;


namespace DAL;
public class DALClass
{
	public CustomerMapperClass _mapper { get; set; }

	string connectionString = $"Server = tcp:vadymrohachkoserver.database.windows.net,1433; Initial Catalog = OnlineStore1; Persist Security Info = False; User ID = VadymRohachkoDB; Password =(1Inspiron1300); MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

	public DALClass()
	{
		this._mapper = new CustomerMapperClass();
	}

	public List<CustomerModelClass> Login(CustomerModelClass user)
	{
		string myQuery1 = "SELECT * FROM Customers where  email = @email and password = @password";

		using (SqlConnection query1 = new SqlConnection(connectionString))
		{
			SqlCommand command = new SqlCommand(myQuery1, query1);
			command.Parameters.AddWithValue("@email", user.email);
			command.Parameters.AddWithValue("@password", user.password);
			command.Connection.Open();
			SqlDataReader results = command.ExecuteReader();

			List<CustomerModelClass> cust = new List<CustomerModelClass>();
			while (results.Read())
			{
				cust.Add(this._mapper.DboToCustomer(results));
			}

			query1.Close();
			return cust;
		}
	}

	public List<CustomerModelClass> Register(CustomerModelClass user)
	{
		string myQuery1 = "INSERT INTO Customers (lastName, firstName, email, password) VALUES(@lastName, @firstName, @email, @password);";

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

				// List<CustomerModelClass> cust = new List<CustomerModelClass>();
				// while (results.Read())
				// {
				// 	cust.Add(this._mapper.DboToCustomer(results));
				// }

				query1.Close();
				//return cust;
			}

			myQuery1 = "SELECT * FROM Customers where  email = @email and password = @password and lastName = @lastName and firstName = @firstName;";

			using (SqlConnection query1 = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(myQuery1, query1);
				command.Parameters.AddWithValue("@email", user.email);
				command.Parameters.AddWithValue("@password", user.password);
				command.Parameters.AddWithValue("@firstName", user.firstName);
				command.Parameters.AddWithValue("@lastName", user.lastName);
				command.Connection.Open();
				SqlDataReader results = command.ExecuteReader();

				List<CustomerModelClass> cust = new List<CustomerModelClass>();
				while (results.Read())
				{
					cust.Add(this._mapper.DboToCustomer(results));
				}

				query1.Close();
				return cust;
			}
		}
		catch (System.Exception)
		{
			return new List<CustomerModelClass>();
		}

	}
}
