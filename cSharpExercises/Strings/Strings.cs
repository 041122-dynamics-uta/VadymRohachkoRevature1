using System;

namespace StringManipulationChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
			/*
			*
			* implement the required code here and within the methods below.
			*
			*/

			Char localChar = new char();
			String dogAndFoxString = "The sly fox is jumping over the silly dog.";
			String stringToConvert = "nadsfsd";
			String firstName = "John";
			String lastName = "Doe";
			String greeting = " Hello ";

			Console.WriteLine($"\nOriginal: {stringToConvert}\n");

			String newString = StringToUpper(stringToConvert);
			Console.WriteLine($"{newString}\n");

			newString = StringToLower(newString);
			Console.WriteLine($"{newString}\n");

			String stringWithTrailingAndLeadingSpaces = greeting;
			String stringWithoutTrailingAndLeadingSpaces = "";
			stringWithoutTrailingAndLeadingSpaces = StringTrim(stringWithTrailingAndLeadingSpaces);
			Console.WriteLine($"Original: {stringWithTrailingAndLeadingSpaces}");
			Console.WriteLine($"Length before: {stringWithTrailingAndLeadingSpaces.Length}");
			Console.WriteLine($"Length after: {stringWithoutTrailingAndLeadingSpaces.Length}\n");

			Console.WriteLine($"Original: {dogAndFoxString}");
			Console.WriteLine(StringSubstring(dogAndFoxString, 0, 0));
			Console.WriteLine(StringSubstring("", 2, 10));
			Console.WriteLine(StringSubstring(dogAndFoxString, -2, 10));
			Console.WriteLine(StringSubstring(dogAndFoxString, 2, -10));
			Console.WriteLine(StringSubstring(dogAndFoxString, 2, 100));
			Console.WriteLine(StringSubstring(dogAndFoxString, 200, 10));
			Console.WriteLine(StringSubstring(dogAndFoxString, 2, 10));
			Console.WriteLine();

			localChar = 's';
			Console.WriteLine($"The index of '{localChar}' is {SearchChar(dogAndFoxString, localChar)}\n");

			Console.WriteLine(ConcatNames(firstName, lastName));
		}

        /// <summary>
        /// This method has one string parameter and will: 
        /// 1) change the string to all upper case and 
        /// 2) return the new string.
        /// </summary>
        /// <param name="usersString"></param>
        /// <returns></returns>
        public static string StringToUpper(string usersString)
        {
			//throw new NotImplementedException("StringToUpper method not implemented.");
			String innerString = usersString.ToUpper();
			return innerString;
		}

        /// <summary>
        /// This method has one string parameter and will:
        /// 1) change the string to all lower case,
        /// 2) return the new string into the 'lowerCaseString' variable
        /// </summary>
        /// <param name="usersString"></param>
        /// <returns></returns>       
        public static string StringToLower(string usersString)
        {
			//throw new NotImplementedException("StringToUpper method not implemented.");
			String lowerCaseString = usersString.ToLower();
			return lowerCaseString;
		}

        /// <summary>
        /// This method has one string parameter and will:
        /// 1) trim the whitespace from before and after the string, and
        /// 2) return the new string.
        /// HINT: When getting input from the user (you are the user), try inputting "   a string with whitespace   " to see how the whitespace is trimmed.
        /// </summary>
        /// <param name="usersStringWithWhiteSpace"></param>
        /// <returns></returns>
        public static string StringTrim(string usersStringWithWhiteSpace)
        {
			//throw new NotImplementedException("StringTrim method not implemented.");
			String newString = usersStringWithWhiteSpace.Trim();
			return newString;
		}

        /// <summary>
        /// This method has three parameters, one string and two integers. It will:
        /// 1) get the substring based on the first integer element and the length 
        /// of the substring desired.
        /// 2) return the substring.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="firstElement"></param>
        /// <param name="lastElement"></param>
        /// <returns></returns>
        public static string StringSubstring(string x, int firstElement, int lengthOfSubsring)
        {
			String subString = "";

			try
			{
				if (x.Length == 0)
				{
					throw new StringManipulationChallengeException("Length of string can't be 0");
				}
				else if (firstElement < 0 || lengthOfSubsring < 0)
				{
					throw new StringManipulationChallengeException("Argument can't be less than 0");
				}
				else if (firstElement > x.Length)
				{
					throw new StringManipulationChallengeException("First argument is Out of range");
				}
				else if ((firstElement + lengthOfSubsring) > x.Length)
				{
					throw new StringManipulationChallengeException("Second argument is Out of range");
				}
				else
				{
					subString = x.Substring(firstElement, lengthOfSubsring);
					return subString;
				}
			}
			catch (StringManipulationChallengeException ex)
			{
				return $"Error: {ex.Message}";
			}
		}

        /// <summary>
        /// This method has two parameters, one string and one char. It will:
        /// 1) search the string parameter for first occurrance of the char parameter and
        /// 2) return the index of the char.
        /// HINT: Think about how StringTrim() (above) would be useful in this situation
        /// when getting the char from the user. 
        /// </summary>
        /// <param name="userInputString"></param>
        /// <param name="charUserWants"></param>
        /// <returns></returns>
        public static int SearchChar(string userInputString, char charUserWants)
        {
			//throw new NotImplementedException("SearchChar method not implemented.");
			return userInputString.IndexOf(charUserWants);
		}

        /// <summary>
        /// This method has two string parameters. It will:
        /// 1) concatenate the two strings with a space between them.
        /// 2) return the new string.
        /// HINT: You will need to get the users first and last name in the 
        /// main method and send them as arguments.
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <returns></returns>
        public static string ConcatNames(string fName, string lName)
        {
			//throw new NotImplementedException("ConcatNames method not implemented.");
			String strToReturn = "";
			strToReturn = String.Concat(fName, " ", lName); //$"{fName} {lName}";
			return strToReturn;
		}
    }//end of program

	class StringManipulationChallengeException : Exception
	{
		public StringManipulationChallengeException() { }

		public StringManipulationChallengeException(string message) : base(message) { }
	}

}
