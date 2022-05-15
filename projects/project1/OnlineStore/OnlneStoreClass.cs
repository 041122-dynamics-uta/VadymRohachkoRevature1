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







