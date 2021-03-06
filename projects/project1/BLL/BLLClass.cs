using System;
using Models;
using DAL;
using System.Collections.Generic;

namespace BLL;
public class BLLClass
{
	private Guid _userGuid = Guid.NewGuid();
	public List<CustomerModelClass> ProcessLogin(Dictionary<string, string> user, DALClass dalObj)
	{
		CustomerModelClass customer = new CustomerModelClass();
		customer.email = user["email"];
		customer.password = user["password"];

		return dalObj.Login(customer);
	}

	public List<CustomerModelClass> ProcessRegister(Dictionary<string, string> user, DALClass dalObj)
	{
		CustomerModelClass customer = new CustomerModelClass();
		customer.email = user["email"];
		customer.password = user["password"];
		customer.firstName = user["firstName"];
		customer.lastName = user["lastName"];

		return dalObj.Register(customer);
	}

	public List<LogModelClass> ProcessLogRequest(int id, DALClass dalObj)
	{
		return dalObj.GetLog(id);
	}

	public List<StoreLocationModelClass> ProcessStoreLocationRequest(DALClass dalObj)
	{

		return dalObj.GetStoreLocation();
	}

	public List<CategoryModelClass> ProcessCategoryRequest(DALClass dalObj)
	{
		return dalObj.GetCategory();
	}

	public List<OrderModelClass> ProcessOrderRequest(int id, DALClass dalObj)
	{
		return dalObj.GetOrder(id);
	}

	public List<CartModelClass> ProcessCartRequest(DALClass dalObj)
	{
		return dalObj.GetCart(_userGuid);
	}

	public List<ProductModelClass> ProcessProductRequest(DALClass dalObj, int storeId, int categoryId)
	{
		return dalObj.GetProduct(storeId, categoryId);
	}

	public bool AddProductToCart(int customerId, int storeId, int productId, int quantity, DALClass dalObj)
	{
		return dalObj.AddProductToCart(_userGuid, customerId, storeId, productId, quantity);
	}

	public bool CheckProductAvailable(int storeId, int productId, int quantity, DALClass dalObj)
	{
		return dalObj.CheckProduct(storeId, productId, quantity);
	}

	public bool DeleteProductFromCart(int productId, DALClass dalObj)
	{
		if (dalObj.CheckProductInCart(_userGuid, productId))
		{
			//dalObj.DecreaseORIncreaseProductAvailability(_userGuid, productId, 1, true);
			return dalObj.DeleteProductFromCart(_userGuid, productId);
		}
		return false;
	}

	public bool SaveLogToDisk(int userId, DALClass dalObj)
	{
		try
		{
			List<string> lines = new List<string>();
			bool isSaved = false;
			List<LogModelClass> logs = dalObj.GetLog(userId);

			foreach (var item in logs)
			{
				lines.Add($"{item.DateTime}  {item.ActionName}");
			}
			string docPath =
				Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "online_store.txt")))
			{
				foreach (string line in lines)
					outputFile.WriteLine(line);
			}
			return true;
		}
		catch (System.Exception)
		{
			return false;
		}

	}

}
