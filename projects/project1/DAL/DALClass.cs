﻿using System;
using Models;
using System.Data.SqlClient; //dotnet add package System.Data.SqlClient --version 4.8.3

namespace DAL;
public class DALClass
{
	public CustomerMapperClass _mapper { get; set; }
	public LogMapperClass _log { get; set; }
	public StoreLocationMapperClass _location { get; set; }
	public CategoryMapperClass _category { get; set; }
	public OrderMapperClass _order { get; set; }
	public CartMapperClass _cart { get; set; }
	public ProductByStoreMapperClass _productByStore { get; set; }

	string connectionString = $"Server = tcp:vadymrohachkoserver.database.windows.net,1433; Initial Catalog = OnlineStore1; Persist Security Info = False; User ID = VadymRohachkoDB; Password = The1OnlineStore!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

	public DALClass()
	{
		this._mapper = new CustomerMapperClass();
		this._log = new LogMapperClass();
		this._location = new StoreLocationMapperClass();
		this._category = new CategoryMapperClass();
		this._order = new OrderMapperClass();
		this._cart = new CartMapperClass();
		this._productByStore = new ProductByStoreMapperClass();
	}



	public List<ProductByStoreModelClass> GetProductByStore(int storeId)
	{
		List<ProductByStoreModelClass> products = new List<ProductByStoreModelClass>();
		//string myQuery1 = "SELECT * FROM Products where orderId = @storeId;";
		//string myQuery1 = "SELECT * FROM Products JOIN Stores ON Products.productId = Stores.productId WHERE stores.storeId = @storeId;";
		string myQuery1 = "SELECT Products.productId, Products.categoryId, Products.currentPrice, Products.totalQuantity, Stores.storeId, Stores.quantity, Stores.location, ProductDescs.name, ProductDescs.author, ProductDescs.isbn, ProductDescs.description, ProductDescs.album, ProductDescs.company, ProductDescs.version  FROM Products JOIN Stores ON Products.productId = Stores.productId JOIN ProductDescs ON Products.descId = ProductDescs.descId WHERE stores.storeId = @storeId;";

		using (SqlConnection query1 = new SqlConnection(connectionString))
		{
			SqlCommand command = new SqlCommand(myQuery1, query1);
			command.Parameters.AddWithValue("@storeId", storeId);
			command.Connection.Open();
			SqlDataReader results = command.ExecuteReader();

			while (results.Read())
			{
				products.Add(this._productByStore.DboToProductByStore(results));
			}
			query1.Close();
			return products;
		}
	}

	public List<CartModelClass> GetCart(int customerId)
	{
		List<CartModelClass> carts = new List<CartModelClass>();
		string myQuery1 = "SELECT * FROM Carts where customerId = @customerId;";

		using (SqlConnection query1 = new SqlConnection(connectionString))
		{
			SqlCommand command = new SqlCommand(myQuery1, query1);
			command.Parameters.AddWithValue("@customerId", customerId);
			command.Connection.Open();
			SqlDataReader results = command.ExecuteReader();

			while (results.Read())
			{
				carts.Add(this._cart.DboToCart(results));
			}
			query1.Close();
			return carts;
		}
	}

	public List<OrderModelClass> GetOrder(int customerId)
	{
		List<OrderModelClass> orders = new List<OrderModelClass>();
		string myQuery1 = "SELECT * FROM Orders where customerId = @customerId;";

		using (SqlConnection query1 = new SqlConnection(connectionString))
		{
			SqlCommand command = new SqlCommand(myQuery1, query1);
			command.Parameters.AddWithValue("@customerId", customerId);
			command.Connection.Open();
			SqlDataReader results = command.ExecuteReader();

			while (results.Read())
			{
				orders.Add(this._order.DboToOrder(results));
			}
			query1.Close();
			return orders;
		}
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

		try
		{
			using (SqlConnection query2 = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(myQuery2, query2);
				command.Parameters.AddWithValue("@customerId", cust[0].customerId);
				command.Parameters.AddWithValue("@actionId", actionId);
				command.Connection.Open();
				command.ExecuteNonQuery();
				query2.Close();
			}
		}
		catch (ArgumentOutOfRangeException)
		{
			return new List<CustomerModelClass>();
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
