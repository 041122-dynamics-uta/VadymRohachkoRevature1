using System;
using System.Collections;
using System.Collections.Generic;

namespace _11_ArraysAndListsChallenge
{
	public class Program
	{
		public static void Main(string[] args)
		{
			int[] arr = { 1, 2, 3 };
			Console.WriteLine($"AverageOfValues retuns: {AverageOfValues(arr)}");

			int[] digits = { 1, 1, 1 };
			digits = SunIsShining(digits);
			foreach (var item in digits)
			{
				Console.WriteLine($"SunIsShining returns: {item}");
			}

			ArrayList myAl = new ArrayList();
			myAl.Add(1);
			myAl.Add("adsfasd");
			myAl.Add(1.1111111111111);
			Console.WriteLine($"ArrayListAvg returns: {ArrayListAvg(myAl)}");

			List<string> animals = new List<string>();
			animals.Add("Cow");
			animals.Add("Camel");
			animals.Add("Elephant");
			Console.WriteLine($"FindStringInList returns: {FindStringInList(animals, "Camel")}");

			List<int> scores = new List<int>() { 12, 21, 50, 1, 7, 8, 10 };
			Console.WriteLine($"ListAscendingOrder returns: {ListAscendingOrder(scores, 3)}");

		}//EoM

		/// <summary>
		/// This method takes an array of integers and returns a double, the average 
		/// value of all the integers in the array
		/// </summary>
		/// <param name="array"
		///       ></param>
		/// <returns></returns>
		public static double AverageOfValues(int[] array)
		{
			int sum = 0;
			foreach (var item in array)
			{
				sum = sum + item;
			}

			return sum / array.Length;
		}

		/// <summary>
		/// This method increases each array element by 2 and 
		/// returns an array with the altered values.
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static int[] SunIsShining(int[] x)
		{
			int[] alteredArr = new int[x.Length];

			for (int j = 0; j < x.Length; j++)
			{
				alteredArr[j] = x[j] * 2;
			}

			return alteredArr;
		}

		/// <summary>
		/// This method takes an ArrayList containing types of double, int, and string 
		/// and returns the average of the ints and doubles only, as a decimal.
		/// It ignores the string values and rounds the result to 3 decimal places toward the nearest even number.
		/// </summary>
		/// <param name="myArrayList"></param>
		/// <returns></returns>
		public static decimal ArrayListAvg(ArrayList myArrayList)
		{
			decimal result = default;
			decimal temp = default;

			foreach (var item in myArrayList)
			{
				if (item.GetType().ToString().Remove(0, 7) != "String")
				{
					Decimal.TryParse(item.ToString(), out temp);
					result = result + temp;
					temp = default;
				}
			}

			return result;
		}

		/// <summary>
		/// This method returns the rank (starting with 1st place) of a new 
		/// score entered into a list of randomly ordered scores.
		/// </summary>
		/// <param name="myArray1"></param>
		public static int ListAscendingOrder(List<int> scores, int yourScore)
		{
			scores.Add(yourScore);
			scores.Sort();

			return scores.FindIndex(x => x.Equals(yourScore));
		}

		/// <summary>
		/// This method has with two parameters takes a List<string> and a string.
		/// The method returns true if the string parameter is found in the List, otherwise false.
		/// </summary>
		/// <param name="myArray2"></param>
		/// <param name="word"></param>
		/// <returns></returns>
		public static bool FindStringInList(List<string> myArray2, string word)
		{
			return myArray2.Contains(word) ? true : false;
		}
	}//EoP
}// EoN