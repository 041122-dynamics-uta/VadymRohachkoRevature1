using System;
using Models;
using DAL;
using System.Collections.Generic;

namespace BLL;
public class BLLClass
{

	public void ProcessLogin(CustomerModelClass customer)
	{

	}

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


	}

}
