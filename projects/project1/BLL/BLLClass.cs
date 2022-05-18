using System;
using System.Runtime.InteropServices;
using Models;
using DAL;
using System.Collections.Generic;

namespace BLL;
public class BLLClass
{
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

	public List<CartModelClass> ProcessCartRequest(int id, DALClass dalObj)
	{
		return dalObj.GetCart(id);
	}

	public List<ProductByStoreModelClass> ProcessProductByStoreRequest(int storeId, DALClass dalObj)
	{
		return dalObj.GetProductByStore(storeId);
	}

	public string WriteFileToDisk(CustomerModelClass custObj, DALClass dalObj)
	{
		List<LogModelClass> listOfCustomerLogs = dalObj.GetLog(custObj.customerId);

		if (listOfCustomerLogs.Count == 0)
		{
			return "No records for logfile to save for this user :(\n";
		}
		string[] logs = new string[listOfCustomerLogs.Count];

		for (int i = 0; i < listOfCustomerLogs.Count; i++)
		{
			logs[i] = $"#{i + 1} {listOfCustomerLogs[i].DateTime} {listOfCustomerLogs[i].ActionName}";
		}

		string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
		string FilePath = Path.Combine(userFolder, $"{custObj.lastName}_{custObj.firstName}_LogFile.txt");

		try
		{
			System.IO.File.WriteAllLines(FilePath, logs);
		}
		catch (Exception err)
		{
			Console.WriteLine("Failed to save data to logfile.\n");
		}

		return "Lines written to file successfully.\n";
	}

	public string ProcessLogDownloadRequest(CustomerModelClass custObj, DALClass dalObj)
	{
		if (GetOperatingSystem() == 0)
		{
			return "Failed to save logfile to disk (Can not define OS).\n";
		}
		else if (GetOperatingSystem() != 3)
		{
			return "Failed to save logfile to disk (Only Windows is Ok).\n";
		}

		return WriteFileToDisk(custObj, dalObj);
	}


	private int GetOperatingSystem()
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
		{
			return 1;
		}

		if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
		{
			return 2;
		}

		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			return 3;
		}

		return 0;
	}
}
