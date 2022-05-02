using System;

namespace _3_DataTypeAndVariablesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
			byte myByte = 0;
			sbyte mySbyte = -128;
			int myInt = -2147483648;
			uint myUint = 0;
			short myShort = -32768;
			ushort myUshort = 0;
			long myLong = -9223372036854775808;
			ulong myUlong = 18446744073709551615;
			float myFloat = default(float);
			double myDouble = default(double);
			char myChar = ' ';
			bool myBool = true;
			object myObject = new Object();
			string myString = "";
			decimal myDecimal = default(decimal);

			object[] types = { myByte, mySbyte, myInt, myUint, myShort, myUshort, myLong, myUlong, myFloat, myDouble, myChar, myBool, myString, myDecimal, myObject };
			foreach (var item in types)
			{
				Console.WriteLine(PrintValues(item));
			}

			Console.WriteLine(StringToInt("12d34"));
			Console.WriteLine(StringToInt("1234"));


		}

        /// <summary>
        /// This method has an 'object' type parameter. 
        /// 1. Create a switch statement that evaluates for the data type of the parameter
        /// 2. You will need to get the data type of the parameter in the 'case' part of the switch statement
        /// 3. For each data type, return a string of exactly format, "Data type => <type>" 
        /// 4. For example, an 'int' data type will return ,"Data type => int",
        /// 5. A 'ulong' data type will return "Data type => ulong",
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string PrintValues(object obj)
        {
			String output = "Data type =>";
			String prossesedInput = obj.GetType().ToString().Remove(0, 7);

			switch (prossesedInput)
			{
				case "Byte":
					output = $"{output} byte";
					break;
				case "SByte":
					output = $"{output} sbyte";
					break;
				case "Int32":
					output = $"{output} int";
					break;
				case "UInt32":
					output = $"{output} uint";
					break;
				case "Int16":
					output = $"{output} short";
					break;
				case "UInt16":
					output = $"{output} ushort";
					break;
				case "Int64":
					output = $"{output} long";
					break;
				case "UInt64":
					output = $"{output} ulong";
					break;
				case "Single":
					output = $"{output} float";
					break;
				case "Double":
					output = $"{output} double";
					break;
				case "Char":
					output = $"{output} char";
					break;
				case "Boolean":
					output = $"{output} bool";
					break;
				case "Object":
					output = $"{output} object";
					break;
				case "String":
					output = $"{output} string";
					break;
				case "Decimal":
					output = $"{output} decimal";
					break;
				default:
					output = "Unknown type";
					break;
			}
			return output;
			// throw new NotImplementedException($"PrintValues() has not been implemented");
		}

        /// <summary>
        /// THis method has a string parameter.
        /// 1. Use the .TryParse() method of the Int32 class (Int32.TryParse()) to convert the string parameter to an integer. 
        /// 2. You'll need to investigate how .TryParse() and 'out' parameters work to implement the body of StringToInt().
        /// 3. If the string cannot be converted to a integer, return 'null'. 
        /// 4. Investigate how to use '?' to make non-nullable types nullable.
        /// </summary>
        /// <param name="numString"></param>
        /// <returns></returns>
        public static int? StringToInt(string numString)
        {
			int result;
			int? output = int.TryParse(numString, out result) == true ? result : null;
			return output;
		}
    }// end of class
}// End of Namespace
