using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Models;

namespace UI;
public class UIClass
{

	public void UILogin()
	{

	}

	public bool CheckName(string name)
	{
		if (name.Length < 1 || name.Length > 10)
		{
			return false;
		}
		return true;
	}

	public void GreetUser()
	{
		ClearConsole();
		Console.WriteLine("Welcome to the greatest online store in the world!\n");
	}

	public void GreetCustomer(string lastFirstName)
	{
		Console.WriteLine($"Welcome back {lastFirstName}!");
	}

	public void goodBuyUser(string custName)
	{
		Console.WriteLine($"Good buy {custName}!");
	}

	public string ChooseLoginOrRegister()
	{
		ClearConsole();
		Console.WriteLine("Choose:\n1 - Login\n2 - Register\nAny other key - Quit the app\n");
		string choiceLogingOrRegister = Console.ReadLine();
		return choiceLogingOrRegister;
	}

	public Dictionary<string, string> LoginRegister(bool isToRegister)
	{
		Dictionary<string, string> loginData = new Dictionary<string, string>();

		// process email/login nameme
		string userInput = "";
		bool isWhileTrue = false;
		bool isReturnTOPrevMenu = false;
		bool isValid = false;

		if (isToRegister == true)
		{
			ClearConsole();
			displayHintTOMoveToPrevMenue();
			string lastName = getLastName();

			if (lastName == "q")
			{
				ClearConsole();
				return new Dictionary<string, string>();
			}

			loginData.Add("lastName", lastName);

			ClearConsole();
			displayHintTOMoveToPrevMenue();
			string firstName = getFirstName();

			if (firstName == "q")
			{
				ClearConsole();
				return new Dictionary<string, string>();
			}

			loginData.Add("firstName", firstName);
		}

		ClearConsole();
		displayHintTOMoveToPrevMenue();
		do
		{
			Console.Write("Enter your login (email): ");
			userInput = Console.ReadLine().TrimStart().TrimEnd();
			isValid = checkLogin(userInput);

			if (userInput == "q")
			{
				isReturnTOPrevMenu = true;
				isWhileTrue = true;
			}
			else if (isValid)
			{
				isWhileTrue = true;
			}
			else if (!isValid)
			{
				ClearConsole();
				displayHintTOMoveToPrevMenue();
				displayHintWrongFormat("login");
			}
		} while (isWhileTrue != true);

		if (userInput == "q")
		{
			ClearConsole();
			return new Dictionary<string, string>();
		}

		loginData.Add("email", userInput);

		//process password
		userInput = "";
		isWhileTrue = false;
		isReturnTOPrevMenu = false;

		ClearConsole();
		displayHintTOMoveToPrevMenue();
		do
		{
			Console.Write("Enter your password (more than 2 and less than 20): ");
			userInput = Console.ReadLine().TrimStart().TrimEnd();
			isValid = checkPassword(userInput);

			if (userInput == "q")
			{
				isReturnTOPrevMenu = true;
				isWhileTrue = true;
			}
			else if (isValid)
			{
				isWhileTrue = true;
			}
			else if (!isValid)
			{
				ClearConsole();
				displayHintTOMoveToPrevMenue();
				displayHintWrongFormat("password");
			}
		} while (isWhileTrue != true);

		if (userInput == "q")
		{
			ClearConsole();
			return new Dictionary<string, string>();
		}

		loginData.Add("password", userInput);

		return loginData;
	}


	public string getLastName()
	{
		Console.Write("Enter your Last name: ");
		string lastName = Console.ReadLine().TrimStart().TrimEnd().Replace(" ", "_");
		lastName.TrimStart().TrimEnd().Replace(" ", "_");

		return lastName;
	}

	public string getFirstName()
	{
		Console.Write("Enter your First name: ");
		string firstName = Console.ReadLine().TrimStart().TrimEnd().Replace(" ", "_");

		return firstName;
	}

	public bool checkLogin(string login)
	{
		Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
		Match match = regex.Match(login);
		if (match.Success)
		{
			return true;
		}
		return false;
	}

	public bool CheckEmail(string email)
	{
		Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
		Match match = regex.Match(email);
		if (match.Success)
		{
			return true;
		}
		return false;
	}

	public bool checkPassword(string pass)
	{
		if (pass.Length < 3 || pass.Length > 20)
		{
			return false;
		}
		return true;
	}

	public void ClearConsole()
	{
		//System.Console.Clear();
	}

	public void ExitApp()
	{
		Environment.Exit(0);
	}

	public void displayHintTOMoveToPrevMenue()
	{
		Console.WriteLine("(Enter 'q' to move to the previous menu.)\n");
	}

	public void displayHintWrongFormat(string subject)
	{
		Console.WriteLine($"Wrong {subject} format!\n");
	}

	public string displayOnlineStoreMenu()
	{
		string userInput = "";

		Console.WriteLine("Main menu:\n1 - Cart\n2 - Log\n3 - Stores\n4 - Orders\n5 - Categories\n6 - Print log\nq - Leave the store\n");
		userInput = Console.ReadLine();

		switch (userInput)
		{
			case "1":
			case "2":
			case "3":
			case "4":
			case "5":
			case "6":
			case "q":
				return userInput;
			default:
				ClearConsole();
				displayOnlineStoreMenu();
				break;
		}
		return userInput;
	}

	public void displayLog(List<LogModelClass> listOfLogs)
	{
		if (listOfLogs.Count == 0)
		{
			Console.WriteLine("No logs for this customer");
		}
		else
		{
			System.Console.WriteLine("Your account logs:");
			foreach (var item in listOfLogs)
			{
				Console.WriteLine(item.DateTime + " " + item.ActionName);
			}
			Console.WriteLine();
		}

	}

	public void displayOrder(List<OrderModelClass> listOfOrder)
	{
		if (listOfOrder.Count == 0)
		{
			Console.WriteLine("No orders for this customer :(");
		}
		else
		{
			foreach (var item in listOfOrder)
			{
				Console.WriteLine($"Order #{item.OrderId}\n");
			}
			Console.WriteLine();
		}
	}

	public List<int> displayCart(List<CartModelClass> listOfCart)
	{
		List<int> productIds = new List<int>();

		if (listOfCart.Count == 0)
		{
			Console.WriteLine("No Shopping Cart for this customer :(");
		}
		else
		{
			double grandTotal = 0;
			foreach (var item in listOfCart)
			{
				productIds.Add(item.ProductId);
				grandTotal = grandTotal + item.Total;
				Console.WriteLine($"ProductId: {item.ProductId}   Quantity: {item.Quantity}   PricePerItem: {item.CurrentPrice}   Price: {item.Total}   Title: {item.ProductName}   Author: {item.ProductAuthor}");
			}
			Console.WriteLine($"___________________________________________________TotalPrice: {grandTotal}\n");
		}
		return productIds;
	}

	public void HintToMoveToPrevMenu()
	{
		Console.WriteLine("\nPress 'q' to move to the previous menu");
	}

	public Dictionary<string, string> displayStoreLocation(List<StoreLocationModelClass> listOfLocations)
	{
		Dictionary<string, string> stores = new Dictionary<string, string>();
		if (listOfLocations.Count == 0)
		{
			Console.WriteLine("No locations in our store :(\n");
		}
		else
		{
			System.Console.WriteLine("Our Stores are located in:");
			for (int item = 0; item < listOfLocations.Count; ++item)
			{
				stores.Add(Convert.ToString(listOfLocations[item].StoreId), listOfLocations[item].Location);
				Console.WriteLine($"{listOfLocations[item].StoreId} {listOfLocations[item].Location}");
			}
			Console.WriteLine();
			return stores;
		}
		return new Dictionary<string, string>();
	}

	public List<int> displayProduct(List<ProductModelClass> listOfProducts)
	{
		List<int> products = new List<int>();

		if (listOfProducts.Count == 0)
		{
			Console.WriteLine("No products in this store :(");
		}
		else
		{
			Console.WriteLine($"Locattion: {listOfProducts[0].Location}");
			Console.WriteLine($"Category: {listOfProducts[0].CategoryName}");
			foreach (var item in listOfProducts)
			{
				products.Add(item.ProductId);
				Console.WriteLine($"ID: {item.ProductId} Title: {item.ProductName} Price: {item.CurrentPrice} Availability: {item.Availability} Author: {item.ProductAuthor} Company: {item.ProductCompany}");
			}
		}
		return products;
	}

	public List<int> displayCategory(List<CategoryModelClass> listOfCategory, bool isFullCategoryDescription = false)
	{
		List<int> categories = new List<int>();

		if (listOfCategory.Count == 0)
		{
			Console.WriteLine("No categoriess in our store :(");
		}
		else if (!isFullCategoryDescription)
		{
			Console.WriteLine("Categories in our store:");
			for (var item = 0; item < listOfCategory.Count; ++item)
			{
				categories.Add(listOfCategory[item].CategoryId);
				Console.WriteLine($"{item + 1} {listOfCategory[item].Name}\n     Description: {listOfCategory[item].Description}");
			}
			Console.WriteLine();
		}
		else if (isFullCategoryDescription)
		{
			Console.WriteLine("Categories in our store:");
			for (var item = 0; item < listOfCategory.Count; ++item)
			{
				categories.Add(listOfCategory[item].CategoryId);
				Console.WriteLine($"{item} {listOfCategory[item].CategoryId} - {listOfCategory[item].Name}");
			}
			Console.WriteLine();
		}
		return categories;
	}

}


