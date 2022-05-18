using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Models;

namespace UI;
public class UIClass
{

	public void GreetUser()
	{
		ClearConsole();
		Console.WriteLine("Welcome to the digital products online store!\n");
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
		//ClearConsole();
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
		Console.Clear();
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

		Console.WriteLine("Main menu:\n1 - Cart\n2 - Categories\n3 - Stores\n4 - Orders\n5 - Log to Screen\n6 - Download Log to File\nq - Leave the store\n");
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
			//Console.WriteLine(listOfLogs.Count);
			foreach (var item in listOfLogs)
			{
				Console.WriteLine(item.DateTime + " " + item.ActionName);
			}
			Console.WriteLine();
		}

	}

	public void displayStoreLocation(List<StoreLocationModelClass> listOfLocations)
	{
		if (listOfLocations.Count == 0)
		{
			Console.WriteLine("No locations in our store :(");
		}
		else
		{
			foreach (var item in listOfLocations)
			{
				Console.WriteLine($"#{item.StoreId} located in:  {item.Location}");
			}
			Console.WriteLine();
		}
	}

	public void displayCategory(List<CategoryModelClass> listOfCategory)
	{
		if (listOfCategory.Count == 0)
		{
			Console.WriteLine("No categoriess in our store :(");
		}
		else
		{
			foreach (var item in listOfCategory)
			{
				Console.WriteLine($"Category #{item.CategoryId}\nName: {item.Name}\nDescription: {item.Description}\n");
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

	public void displayCart(List<CartModelClass> listOfCart)
	{
		if (listOfCart.Count == 0)
		{
			Console.WriteLine("No Shopping Cart for this customer :(");
		}
		else
		{
			foreach (var item in listOfCart)
			{
				Console.WriteLine($"Order #{item.CartId}\n");
			}
			Console.WriteLine();
		}
	}

	public void displayProductByStore(List<ProductByStoreModelClass> listOfProduct)
	{
		if (listOfProduct.Count == 0)
		{
			Console.WriteLine("No Products in this store :(");
		}
		else
		{
			foreach (var item in listOfProduct)
			{
				Console.WriteLine($"Order #{item.ProductId.ToString()}\n");
			}
			Console.WriteLine();
		}
	}

}


