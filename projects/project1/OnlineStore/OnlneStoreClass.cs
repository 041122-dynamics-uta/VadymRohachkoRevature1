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
//Cart
//list of Logs
//list of Stores
//list of Orders (History)
//list of products
//list of categories
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
		case "2":
			UIManager.displayLog(BLLManager.ProcessLogRequest(currCust.customerId, DALManager));
			string logLeaveInput = "";
			do
			{
				Console.WriteLine("Press q to return to previous menu.\n");
				logLeaveInput = Console.ReadLine();
			} while (logLeaveInput != "q");
			break;
		case "3":
			Dictionary<string, string> stores = UIManager.displayStoreLocation(BLLManager.ProcessStoreLocationRequest(DALManager));
			string storeLocationInput = "";
			do
			{
				Console.WriteLine("Press q to return to previous menu.");
				Console.WriteLine("Choose a store from the list:");
				storeLocationInput = Console.ReadLine();
				//if "q" move to the previous menu
				//if a number from the list, show the content of the store
				if (storeLocationInput != "q")
				{
					UIManager.HintToMoveToPrevMenu();
					//display the city of the chosen store
					Console.WriteLine($"Store at {stores[storeLocationInput]}");
					string category = "";
					UIManager.displayCategory(BLLManager.ProcessCategoryRequest(DALManager), true);
					do
					{
						category = Console.ReadLine();
						switch (category)
						{
							case "0":
								UIManager.HintToMoveToPrevMenu();
								Console.WriteLine("Show all");
								break;
							case "1":
								UIManager.HintToMoveToPrevMenu();
								Console.WriteLine("Show Books");
								break;
							case "2":
								UIManager.HintToMoveToPrevMenu();
								Console.WriteLine("Show Music");
								break;
							case "3":
								UIManager.HintToMoveToPrevMenu();
								Console.WriteLine("Show Software");
								break;
							case "q":
								UIManager.displayStoreLocation(BLLManager.ProcessStoreLocationRequest(DALManager));
								break;
							default:
								UIManager.HintToMoveToPrevMenu();
								Console.WriteLine("Incorrect input :(");
								break;
						}
					} while (category != "q");
				}
			} while (storeLocationInput != "q");
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
		case "5":
			UIManager.displayCategory(BLLManager.ProcessCategoryRequest(DALManager));
			string categoryInput = "";
			do
			{
				Console.WriteLine("Press q to return to previous menu.\n");
				categoryInput = Console.ReadLine();
			} while (categoryInput != "q");
			break;
		case "q":
			quit = true;
			break;
	}

} while (!quit);

UIManager.ClearConsole();
UIManager.goodBuyUser(currCust.lastName + " " + currCust.firstName);
UIManager.ExitApp();






