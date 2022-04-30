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
	 * Complete the 'migratoryBirds' function below.
	 *
	 * The function is expected to return an INTEGER.
	 * The function accepts INTEGER_ARRAY arr as parameter.
	 */

	public static int migratoryBirds(List<int> arr)
	{
		Dictionary<int, int> birdsDict = new Dictionary<int, int>();
		List<Dictionary<int, int>> birdsList = new List<Dictionary<int, int>>();

		foreach (var item in arr)
		{
			if (!birdsDict.ContainsKey(item))
			{
				birdsDict.Add(item, 1);
			}
			else
			{
				birdsDict[item] += 1;
			}
		}

		//order by key
		birdsDict = birdsDict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

		var bestBird = birdsDict.ElementAt(0);
		int result = bestBird.Value;

		for (int index = 1; index < birdsDict.Count; index++)
		{
			if (birdsDict.ElementAt(index).Value > bestBird.Value)
			{
				bestBird = birdsDict.ElementAt(index);
			}
		}

		return bestBird.Key;
	}

}

class Solution
{
	public static void Main(string[] args)
	{
		TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

		int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

		List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

		int result = Result.migratoryBirds(arr);

		textWriter.WriteLine(result);

		textWriter.Flush();
		textWriter.Close();
	}
}
