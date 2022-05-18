using System;
using Models;
using DAL;
using System.Collections.Generic;

namespace BLL;
public class BLLClass
{

	// public void ProcessLogin(CustomerModelClass customer)
	// {

	// }

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

}
