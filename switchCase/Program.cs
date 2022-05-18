//int quantity = 3;

Console.WriteLine("Enter quantity:");
int quantity = Convert.ToInt32(Console.ReadLine());

switch (quantity)
{
	case 1:
		Console.WriteLine("one");
		break;
	case 2:
		Console.WriteLine("two");
		break;
	case 3:
		Console.WriteLine("three");
		break;
	case 4:
		Console.WriteLine("four");
		break;
	case 5:
		Console.WriteLine("five");
		break;
	default:
		Console.WriteLine("wrong input");
		break;
}
