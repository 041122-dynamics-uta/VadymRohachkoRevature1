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

// bool _level10 = true;
// bool _level20 = false;

// UIManager.GreetUser();

// while (_level10)
// {
// 	Console.WriteLine("Entrance Menu");
// 	Console.WriteLine("1 Login");
// 	Console.WriteLine("2 Register");
// 	Console.WriteLine("q Quit the app\n");

// 	bool _level11 = true;
// 	bool _level12 = false;
// 	bool _level13 = false;

// 	string userInputEntanceMenu = Console.ReadLine();
// 	switch (userInputEntanceMenu)
// 	{
// 		case "q":
// 			System.Console.WriteLine("See you later!");
// 			_level10 = false;
// 			//Environment.Exit(0);
// 			break;
// 		case "1":
// 			System.Console.WriteLine("Login processing...");
// 			Dictionary<string, string> loginData = new Dictionary<string, string>();
// 			while (_level11)
// 			{
// 				System.Console.WriteLine("Press 'q' to quit Login");
// 				System.Console.Write("Enter your login (email):");
// 				string userInputEmail = Console.ReadLine();
// 				System.Console.WriteLine();
// 				switch (userInputEmail)
// 				{
// 					case "q":
// 						_level11 = false;
// 						break;
// 					default:
// 						if (!UIManager.CheckEmail(userInputEmail))
// 						{
// 							System.Console.WriteLine("Error: Incorrect email format!\n");
// 						}
// 						else
// 						{
// 							loginData.Add("email", userInputEmail);
// 							_level11 = false;
// 							_level12 = true;
// 						}
// 						break;
// 				}
// 			}//END _level11
// 			while (_level12)
// 			{
// 				System.Console.WriteLine("Press 'q' to quit Login");
// 				System.Console.Write("Enter your Password:");
// 				string userInputPassword = Console.ReadLine();
// 				System.Console.WriteLine();
// 				switch (userInputPassword)
// 				{
// 					case "q":
// 						_level12 = false;
// 						break;
// 					default:
// 						if (!UIManager.checkPassword(userInputPassword))
// 						{
// 							System.Console.WriteLine("Error: Incorrect password format!\n");
// 						}
// 						else
// 						{
// 							loginData.Add("password", userInputPassword);
// 							_level12 = false;
// 							_level13 = true;
// 						}
// 						break;
// 				}
// 			}//END _level12

// 			while (_level13)
// 			{
// 				custObjListLogin = BLLManager.ProcessLogin(loginData, DALManager);
// 				if (custObjListLogin.Count != 1)
// 				{
// 					System.Console.WriteLine("Error: Email and\\or Password is incorrect!\n");
// 					_level13 = false;
// 				}
// 				else
// 				{
// 					System.Console.WriteLine("Welcome back!\n");
// 					_level13 = false;
// 					_level10 = false;
// 					_level20 = true;
// 				}
// 			}//END _level13
// 			break;
// 		case "2":
// 			System.Console.WriteLine("Go to Register\n");
// 			_level20 = true;
// 			break;
// 		default:
// 			System.Console.WriteLine("Error: Wrong input!\n");
// 			break;
// 	}

// 	while (_level20)
// 	{
// 		System.Console.WriteLine("Main Menu:");
// 		System.Console.WriteLine("'1' Go to Store");
// 		System.Console.WriteLine("'2' Go to Cart");
// 		System.Console.WriteLine("'3' See Locations");
// 		System.Console.WriteLine("'4' See Categories");
// 		System.Console.WriteLine("'5' See Log");
// 		System.Console.WriteLine("'6' Save Log to Disk");
// 		System.Console.WriteLine("'q' Logoff\n"); //the global vars should be reset at this point

// 		string userInputMainMenu = Console.ReadLine();
// 		switch (userInputMainMenu)
// 		{
// 			case "q":
// 				_level20 = false;
// 				_level10 = true;
// 				currCust = null;
// 				custObjListLogin = null;
// 				custObjListRegister = null;
// 				System.Console.WriteLine("You logged off.\n");
// 				break;
// 			case "1":
// 				System.Console.WriteLine("Store");
// 				break;
// 			case "2":
// 				System.Console.WriteLine("Cart");
// 				break;
// 			case "3":
// 				while (true)
// 				{
// 					UIManager.displayStoreLocation(BLLManager.ProcessStoreLocationRequest(DALManager));
// 					System.Console.WriteLine("Press 'q' to return to the previous menu.\n");
// 					if (Console.ReadLine() == "q")
// 					{
// 						break;
// 					}
// 				}
// 				break;
// 			case "4":
// 				while (true)
// 				{
// 					UIManager.displayCategory(BLLManager.ProcessCategoryRequest(DALManager));
// 					System.Console.WriteLine("Press 'q' to return to the previous menu.\n");
// 					if (Console.ReadLine() == "q")
// 					{
// 						break;
// 					}
// 				}
// 				break;
// 			case "5":
// 				while (true)
// 				{
// 					UIManager.displayLog(BLLManager.ProcessLogRequest(currCust.customerId, DALManager));
// 					System.Console.WriteLine("Press 'q' to return to the previous menu.\n");
// 					if (Console.ReadLine() == "q")
// 					{
// 						break;
// 					}
// 				}
// 				break;
// 			case "6":
// 				if (BLLManager.SaveLogToDisk(currCust.customerId, new DALClass()))
// 				{
// 					Console.WriteLine("You log successfully saved to disk  ...MyDocuments/online_store.txt\n");
// 				}
// 				else
// 				{
// 					Console.WriteLine("Failed to saved to disk!\n");
// 				}
// 				break;
// 			default:
// 				System.Console.WriteLine("Error: Wrong input!");
// 				break;
// 		}

// 	}
// }

// Environment.Exit(0);

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
			List<int> productIds = UIManager.displayCart(BLLManager.ProcessCartRequest(DALManager));
			string cartInput = "";
			do
			{
				if (productIds.Count == 0)
				{
					Console.WriteLine("Press 'q' to return to previous menu.");
					cartInput = Console.ReadLine();
				}
				else
				{
					Console.WriteLine("Press 'q' to return to previous menu.");
					Console.WriteLine("Press 'd' to delete an item.");
					Console.WriteLine("Press 'c' to checkout.");
					cartInput = Console.ReadLine();
					switch (cartInput)
					{
						case "d":
							do
							{
								Console.WriteLine("Press 'q' to return to previous menu.");
								Console.WriteLine("Enter Product ID to delete from your Shoppin Cart:");
								UIManager.displayCart(BLLManager.ProcessCartRequest(DALManager));
								string productToDelete = Console.ReadLine();
								if (productToDelete == "q")
								{
									break;
								}
								if (productIds.Contains(Convert.ToInt32(productToDelete)))
								{
									Console.WriteLine("Deleting Item...");
									bool isDeleted = BLLManager.DeleteProductFromCart(Convert.ToInt32(productToDelete), new DALClass());
									if (isDeleted)
									{
										Console.WriteLine("Item removed from Shopping Cart");
										productIds = UIManager.displayCart(BLLManager.ProcessCartRequest(DALManager));
										break;
									}
									else
									{
										Console.WriteLine("Failed to remove the item from Shopping Cart");
									}

								}
								else if (!productIds.Contains(Convert.ToInt32(productToDelete)))
								{
									Console.WriteLine("Incorrect Id");
								}
							} while (true);

							break;
						case "c":
							string payUserInput = "";
							// do
							// {
							// 	Console.WriteLine("Press 'q' to return to previous menu.");
							// 	Console.WriteLine("Press 'p' to pay for the items in your Shoppin Cart");
							// 	payUserInput = Console.ReadLine();
							// 	if (payUserInput != "q" && payUserInput == "p")
							// 	{
							// 		Console.WriteLine("Transferring funds...");
							// 		payUserInput != "q";
							// 	}

							// } while (payUserInput != "q");
							break;
					}
				}
			} while (cartInput != "q");
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
		case "6":
			Console.WriteLine("Saving Log to the disk...");
			if (BLLManager.SaveLogToDisk(currCust.customerId, new DALClass()))
			{
				Console.WriteLine("Saved to disk in ...MyDocuments/online_store.txt\n");
			}
			else
			{
				Console.WriteLine("Failed to saved to disk!\n");
			}
			break;
		case "q":
			quit = true;
			break;
	}

} while (!quit);

UIManager.ClearConsole();
UIManager.goodBuyUser(currCust.lastName + " " + currCust.firstName);
UIManager.ExitApp();






