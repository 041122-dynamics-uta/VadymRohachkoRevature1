using System;
using BLL;
using DAL;
using UI;
using System.Collections.Generic;
using Models;

UIClass UIManager = new UIClass();
BLLClass BLLManager = new BLLClass();
DALClass DALManager = new DALClass();
CustomerModelClass currCust = new CustomerModelClass();
bool flag = false;
List<CustomerModelClass> custObjListLogin;
List<CustomerModelClass> custObjListRegister;

UIManager.GreetUser();

do
{
	switch (UIManager.ChooseLoginOrRegister())
	{
		case "1":
			Dictionary<string, string> userInputLogin = UIManager.LoginRegister(false);

			if (userInputLogin.Count > 0)
			{
				custObjListLogin = BLLManager.ProcessLogin(userInputLogin, DALManager);
				if (custObjListLogin.Count > 0)
				{
					flag = true;
					currCust = custObjListLogin[0];
					Console.WriteLine($"\nWelcome back {currCust.lastName} {currCust.firstName}!\n");
				}
				else
				{
					Console.WriteLine("Incorrect login and/or password");
				}

			}
			else
			{
				UIManager.ClearConsole();
			}

			break;
		case "2":
			Dictionary<string, string> userInputRegister = UIManager.LoginRegister(true);

			if (userInputRegister.Count > 0)
			{
				custObjListRegister = BLLManager.ProcessRegister(userInputRegister, DALManager);
				if (custObjListRegister.Count > 0)
				{
					currCust = custObjListRegister[0];
					Console.WriteLine("You registerd.\nLogin, please...\n");
				}
				else
				{
					Console.WriteLine("Incorrect login (email)\n");
				}
			}
			else
			{
				UIManager.ClearConsole();
			}
			break;
		default:
			UIManager.ClearConsole();
			UIManager.ExitApp();
			break;
	}
} while (!flag);


//Menu: 
bool quit = false;

UIManager.ClearConsole();
UIManager.GreetCustomer(currCust.lastName + " " + currCust.firstName);

do
{
	string menuChoice = UIManager.displayOnlineStoreMenu();

	switch (menuChoice)
	{
		case "1":
			UIManager.displayCart(BLLManager.ProcessCartRequest(currCust.customerId, DALManager));
			string cartLeaveInput = "";
			do
			{
				Console.WriteLine("Press q to return to previous menu.\n");
				cartLeaveInput = Console.ReadLine();
			} while (cartLeaveInput != "q");
			break;
		case "5":
			UIManager.displayLog(BLLManager.ProcessLogRequest(currCust.customerId, DALManager));
			string logLeaveInput = "";
			do
			{
				Console.WriteLine("Press q to return to previous menu.\n");
				logLeaveInput = Console.ReadLine();
			} while (logLeaveInput != "q");
			break;
		case "3":
			UIManager.displayStoreLocation(BLLManager.ProcessStoreLocationRequest(DALManager));
			string storeLocationInput = "";
			bool isToReturnToMainMenu = false;
			do
			{
				Console.WriteLine("Press q to return to previous menu.");
				Console.WriteLine("Choose a store to see the list of products.\n");
				storeLocationInput = Console.ReadLine();

				switch (storeLocationInput)
				{
					case "q":
						isToReturnToMainMenu = true;
						break;
					case "1":
					case "2":
					case "3":
						//Console.WriteLine("Not Available at the moment :(\nCome back later!\n");
						isToReturnToMainMenu = true;
						UIManager.displayProductByStore(BLLManager.ProcessProductByStoreRequest(Int32.Parse(storeLocationInput), DALManager));
						break;
					default:
						Console.WriteLine("Wrong input!");
						break;
				}

			} while (!isToReturnToMainMenu);//(storeLocationInput != "q");
			break;
		case "4":
			UIManager.displayOrder(BLLManager.ProcessOrderRequest(currCust.customerId, DALManager));
			string orderInput = "";
			do
			{
				Console.WriteLine("Press q to return to previous menu.\n");
				orderInput = Console.ReadLine();
			} while (orderInput != "q");
			break;
		case "2":
			UIManager.displayCategory(BLLManager.ProcessCategoryRequest(DALManager));
			string categoryInput = "";
			do
			{
				Console.WriteLine("Press q to return to previous menu.\n");
				categoryInput = Console.ReadLine();
			} while (categoryInput != "q");
			break;
		case "6":

			Console.WriteLine(BLLManager.ProcessLogDownloadRequest(currCust, DALManager));
			break;
		case "q":
			quit = true;
			break;
	}

} while (!quit);

UIManager.ClearConsole();
UIManager.goodBuyUser(currCust.lastName + " " + currCust.firstName);
UIManager.ExitApp();






