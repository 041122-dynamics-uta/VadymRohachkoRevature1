
//Global vars
//to count % 3
int module3 = 0;
//to count % 5
int module5 = 0;
//to count both % 3 and 5
int module35 = 0;
//counter for breaking the line
int numPerLineCounter = 0;

//greeting
Console.WriteLine("Sweet and Salty\n");

//advise to enter the starting number
Console.Write("Enter the starting number:");
//get user's respond
int startNumber = Convert.ToInt32(Console.ReadLine());

//advise to enter the second number
Console.Write("Enter the last number:");
//get user's the respond
int stopNumber = Convert.ToInt32(Console.ReadLine());

//advise to enter the number of words in the line
Console.Write("Enter the length of output:");
//get the respond
int quantityOfNumPrintPerLine = Convert.ToInt32(Console.ReadLine());
//insert an empty line
Console.WriteLine();

//make an array of numbers staring from start number and finishing with the spop number
int[] ints = Enumerable.Range(startNumber, stopNumber - startNumber + 1).ToArray();

//loop through the array
foreach (var item in ints)
{
	//if number % 3 and 5
	if (item % 3 == 0 && item % 5 == 0)
	{
		//increase the word per line counter
		++numPerLineCounter;
		//increase counter of numbers % 3
		++module35;
		//display the message
		Console.Write("Sweet’nSalty ");
	}
	//do, if number % 3 = 0
	else if (item % 3 == 0)
	{
		//increase the word per line counter
		++numPerLineCounter;
		//increase counter of numbers % 3
		++module3;
		//display the message
		Console.Write("Sweet ");
	}
	//do, if number % 5 = 0
	else if (item % 5 == 0)
	{
		//increase the word per line counter
		++numPerLineCounter;
		//increase counter of numbers % 5
		++module5;
		//display the message
		Console.Write("Salty ");
	}
	//do, if counter equal to the number of words in the line desired by the user
	if (numPerLineCounter == quantityOfNumPrintPerLine)
	{
		//make counter = 0
		numPerLineCounter = 0;
		//break th line
		Console.WriteLine();
	}
}

//display quantity of Sweet, Salt and SweetAndSalty
Console.WriteLine($"There are {module3} Sweet\nThere are {module5} Salty.\nThere are {module35} SweetAndSalty.");
