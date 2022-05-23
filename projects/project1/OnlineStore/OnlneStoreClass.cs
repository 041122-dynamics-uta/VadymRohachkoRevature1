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
			UIManager.displayCart(BLLManager.ProcessCartRequest(DALManager));
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
			//get list of stores
			Dictionary<string, string> stores = UIManager.displayStoreLocation(BLLManager.ProcessStoreLocationRequest(DALManager));
			string storeLocationInput = "";
			//work with the stores' choice
			do
			{
				Console.WriteLine("Press q to return to previous menu.");
				Console.WriteLine("Choose a store from the list:");
				storeLocationInput = Console.ReadLine();
				string locationOut = "";
				//check correct store input
				bool isLocation = stores.TryGetValue(storeLocationInput, out locationOut);
				if (!isLocation)
				{
					Console.WriteLine("Incorrect location");
					stores = UIManager.displayStoreLocation(BLLManager.ProcessStoreLocationRequest(DALManager));
				}
				//if "q" move to the previous menu
				//if a number from the list, show the categories
				if (storeLocationInput != "q" && isLocation)
				{
					string category = "";
					string catigoryOut = "";
					List<int> categories = new List<int>();
					do
					{
						UIManager.HintToMoveToPrevMenu();
						Console.WriteLine($"Store at {stores[storeLocationInput]}");
						//display the categories
						categories = UIManager.displayCategory(BLLManager.ProcessCategoryRequest(DALManager), true);
						//choose a category and show contents
						category = Console.ReadLine();
						//check user's input
						bool hasCategory = stores.TryGetValue(storeLocationInput, out catigoryOut);
						switch (category)
						{
							case "1":
							case "2":
							case "3":
								//go to list of products
								string userProductInput = "";
								do
								{
									UIManager.HintToMoveToPrevMenu();
									Console.WriteLine("Choose a product by ID:");
									List<int> products = UIManager.displayProduct(BLLManager.ProcessProductRequest(DALManager, Convert.ToInt32(storeLocationInput), Convert.ToInt32(category)));
									userProductInput = Console.ReadLine();
									try
									{
										//Convert may throw an exception 
										if (userProductInput != "q" && !products.Contains(Convert.ToInt32(userProductInput)))
										{
											Console.WriteLine("Error: Wrong ID");
										}
										else if (userProductInput != "q")
										{
											//put into the cart
											//BLLManager.AddProductToCart(Convert.ToInt32(storeLocationInput), Convert.ToInt32(userProductInput), 1);
											// Console.WriteLine($"Product with ID {userProductInput} was added to the cart!");
											// Console.WriteLine($"The shopping cart contains {0} item/s.");
											// Console.WriteLine($"Total price is ${0}.");
											Console.WriteLine("Adding to Cart...");
											Console.WriteLine($"Enter quantity of product ID{userProductInput}");
											string itemQuantityInStringFormat = Console.ReadLine();
											int itemQuantity = Convert.ToInt32(itemQuantityInStringFormat);
											if (itemQuantity < 1)
											{
												Console.WriteLine("You should pick up more than 0.");
											}
											else
											{
												try
												{
													//add to cart with checking availability (not real quantity in DB)
													//if not available return warning currCust.customerId
													bool isProductAvailable = BLLManager.CheckProductAvailable(Convert.ToInt32(storeLocationInput), Convert.ToInt32(userProductInput), itemQuantity, new DALClass());
													if (isProductAvailable)
													{
														Console.WriteLine($"Product is avalable");
														bool isAdded = BLLManager.AddProductToCart(currCust.customerId, Convert.ToInt32(storeLocationInput), Convert.ToInt32(userProductInput), itemQuantity, new DALClass());
														if (isAdded)
														{
															Console.WriteLine("Added to your cart!");
														}
														else
														{
															Console.WriteLine("Failed to add item/s :(");
														}
													}
													else
													{
														Console.WriteLine($"The quantity of product is NOT avalable :(\nTry to choose less quantity...");
													}

												}
												catch (System.Exception)
												{
													Console.WriteLine("Wrong quantity/format :(\nTry again...");
												}
											}
										}
									}
									catch (System.Exception)
									{
										Console.WriteLine("Error: Wrong ID");
									}

								} while (userProductInput != "q");
								break;
							case "q":
								UIManager.displayStoreLocation(BLLManager.ProcessStoreLocationRequest(DALManager));
								break;
							default:
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






