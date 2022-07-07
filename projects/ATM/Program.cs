using System.Security.AccessControl;
using System.Threading.Tasks.Dataflow;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
public class cardHolder
{
	private String _cardNum;
	private int _pin;
	private String _firstName;
	private String _lastName;
	private double _balance;

	public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
	{
		this._cardNum = cardNum;
		this._pin = pin;
		this._firstName = firstName;
		this._lastName = lastName;
		this._balance = balance;
	}

	public String getNum()
	{
		return _cardNum;
	}

	public int getPin()
	{
		return _pin;
	}

	public String getFirstName()
	{
		return _firstName;
	}

	public String getLastName()
	{
		return _lastName;
	}

	public double getBalance()
	{
		return _balance;
	}

	public void setCardNum(String newCardNum)
	{
		_cardNum = newCardNum;
	}

	public void setPin(int newPin)
	{
		_pin = newPin;
	}

	public void setFirstName(String newFirstName)
	{
		_firstName = newFirstName;
	}

	public void setName(String newFirstName)
	{
		_firstName = newFirstName;
	}

	public void setBalance(double newBalance)
	{
		_balance = newBalance;
	}

	public static void Main(String[] args)
	{
		void printOptions()
		{
			Console.WriteLine("Please choose from one of the following options...");
			System.Console.WriteLine("1. Deposit");
			System.Console.WriteLine("2. Withdraw");
			System.Console.WriteLine("3. Show Balance");
			System.Console.WriteLine("4. Exit");
		}

		void deposit(cardHolder currentUser)
		{
			System.Console.WriteLine("How much $$ would you like to deposit?");
			double deposit = Double.Parse(Console.ReadLine());
			currentUser.setBalance(currentUser.getBalance() + deposit);
			Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
		}

		void withdraw(cardHolder currentUser)
		{
			System.Console.WriteLine("How much $$ would you like to withdraw: ");
			double withdrawal = Double.Parse(Console.ReadLine());
			//check if the user has enough money
			if (currentUser.getBalance() < withdrawal)
			{
				System.Console.WriteLine("Insufficient balance :(");
			}
			else
			{
				currentUser.setBalance(currentUser.getBalance() - withdrawal);
				Console.WriteLine("$$ was withdrawn. Your new balance is: " + currentUser.getBalance());
			}
		}

		void balance(cardHolder currentUser)
		{
			System.Console.WriteLine("Current balance: " + currentUser.getBalance());
		}

		List<cardHolder> cardHolders = new List<cardHolder>();
		cardHolders.Add(new cardHolder("1111222233334444", 1111, "John", "Brown", 150.22));
		cardHolders.Add(new cardHolder("2222111133334444", 2222, "Amy", "Whitehouse", 180.02));
		cardHolders.Add(new cardHolder("3333111122223333", 3333, "Bob", "Raven", 350.21));
		cardHolders.Add(new cardHolder("4444111133332222", 4444, "Frida", "Callo", 250.34));
		cardHolders.Add(new cardHolder("3333222211114444", 5555, "Dawn", "Smith", 1150.54));
		cardHolders.Add(new cardHolder("4444222233331111", 6666, "Ashly", "Dickens", 50.43));


		//promp user
		System.Console.WriteLine("Welcome to SimpleATM");
		System.Console.WriteLine("Please insert your debit card: ");
		String debitCardNum = "";
		cardHolder currentUser;

		while (true)
		{
			try
			{
				debitCardNum = Console.ReadLine();
				//check against DB
				currentUser = cardHolders.FirstOrDefault(a => a._cardNum == debitCardNum);
				if (currentUser != null)
				{
					break;
				}
				else
				{
					System.Console.WriteLine("Card not recognized. Please try again.");
				}
			}
			catch (System.Exception)
			{
				System.Console.WriteLine("Card not recognized. Please try again.");
			}

		}

		System.Console.WriteLine("Please enter your pin: ");
		int userPin = 0;

		while (true)
		{
			try
			{
				userPin = int.Parse(Console.ReadLine());
				if (currentUser.getPin() == userPin) { break; }
				else
				{
					System.Console.WriteLine("Pin not recognized. Please try again.");
				}
			}
			catch (System.Exception)
			{
				System.Console.WriteLine("Pin not recognized. Please try again.");
			}
		}

		System.Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
		int option = 0;
		do
		{
			printOptions();
			try
			{
				option = int.Parse(Console.ReadLine());
			}
			catch
			{

			}
			if (option == 1)
			{
				deposit(currentUser);
			}
			else if (option == 2)
			{
				withdraw(currentUser);
			}
			else if (option == 3)
			{
				balance(currentUser);
			}
			else if (option == 4)
			{
				break;
			}
			else { option = 0; }
		} while (option != 4);
		System.Console.WriteLine("Thank you! Good buy!");


	}//end main
}


