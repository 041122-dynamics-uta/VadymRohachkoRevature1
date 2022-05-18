using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

	/*
	 * Complete the 'sockMerchant' function below.
	 *
	 * The function is expected to return an INTEGER.
	 * The function accepts following parameters:
	 *  1. INTEGER n
	 *  2. INTEGER_ARRAY ar
	 */

	public static int sockMerchant(int n, List<int> ar)
	{
		const int negativeOne = -1;
		const int firstElem = 0;

		int quantityOfPars = 0;
		int matchPosition = negativeOne;

		ar.Sort();

		while (ar.Count > 0)
		{
			int currentElem = ar.ElementAt(firstElem);
			ar.RemoveAt(0);
			matchPosition = ar.FindIndex(x => x == currentElem);
			if (matchPosition != -1)
			{
				ar.RemoveAt(matchPosition);
				matchPosition = negativeOne;
				++quantityOfPars;
			}
		}
		return quantityOfPars;
	}//EOC
}

class Solution
{
	public static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int n = Convert.ToInt32(Console.ReadLine().Trim());

		List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

		int result = Result.sockMerchant(n, ar);

		textWriter.WriteLine(result);

		textWriter.Flush();
		textWriter.Close();
	}
}
