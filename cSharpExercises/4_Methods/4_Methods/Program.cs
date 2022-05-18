using System;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
			Console.WriteLine(GetName());
			Console.WriteLine(GreetFriend(Console.ReadLine()));
			GetNumber();
			GetAction();
			DoAction(2, 0, 4);
		}

        public static string GetName()
        {
			Console.WriteLine("Hi! What is your name?");
			return Console.ReadLine();
		}

        public static string GreetFriend(string name)
        {
			return $"Hello, {name}. You are my friend.";
		}

        public static double GetNumber()
        {
			string input;
			double dInput;
			bool isTrue = false;
			do
			{
				Console.WriteLine("Enter a double");
				input = Console.ReadLine();
				isTrue = double.TryParse(input, out dInput);
			} while (!isTrue);

			return dInput;
		}

        public static int GetAction()
        {
			int input;
			bool isTrue = false;
			int output = default;

			do
			{
				Console.WriteLine("Choose:\n1 Add\n2 Substract\n3 Multiply\n4 Divide\n");
				input = Console.Read();
				if (input > 48 && input < 53)
				{
					isTrue = true;
				}
			} while (!isTrue);

			switch (input)
			{
				case 49:
					output = 1;
					break;
				case 50:
					output = 2;
					break;
				case 51:
					output = 3;
					break;
				case 52:
					output = 4;
					break;
			}
			return output;
		}

        public static double DoAction(double x, double y, int action)
        {
			double output = default;

			switch (action)
			{
				case 1:
					output = x + y;
					Console.WriteLine($"Result is {output}");
					break;
				case 2:
					output = x - y;
					Console.WriteLine($"Result is {output}");
					break;
				case 3:
					output = x * y;
					Console.WriteLine($"Result is {output}");
					break;
				case 4:
					if (y == 0)
					{
						Console.WriteLine("Devider can not be equal 0");
						return output = default;
					}
					output = x / y;
					Console.WriteLine($"Result is {output}");
					break;
			}

			return output;
		}
    }
}
