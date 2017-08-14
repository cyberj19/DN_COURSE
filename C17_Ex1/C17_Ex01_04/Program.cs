namespace C17_Ex01_04
{
    public class Program
    {
        // public because it is being used by C17_Ex01_05.Program
        public enum eStringType
        {
            Numeric,
            Alphabetic,
        }

        private const uint k_NumOfCharsInString = 10;

        static void Main(string[] args)
        {
            analyzeAndPrintStringFromUser();
        }

        // Getting an input string from user and analyzes it
        private static void analyzeAndPrintStringFromUser() 
        {
            analyzeStringAndPrint(getStringFromUser());
        }
        
        // Getting a valid string from user
        private static string getStringFromUser()
        {
            string userInput = string.Empty;
            bool isValidInput;

            System.Console.WriteLine("Please enter a numeric or an alphabetic string with the length of {0} characters:", k_NumOfCharsInString);
            do
            {
                userInput = System.Console.ReadLine();
                isValidInput = (userInput.Length == k_NumOfCharsInString) && isAlphabeticOrNumericString(userInput);
                if (!isValidInput)
                {
                    System.Console.WriteLine("Invalid input! Please try again:");
                }
            }
            while (!isValidInput);
     
            return userInput;
        }

        // Checks whether a string contains exclusively numeric or alphabetic characters but not both (not alphanumric!)
        private static bool isAlphabeticOrNumericString(string i_Str)
        {
            return IsStringType(i_Str, eStringType.Alphabetic) || IsStringType(i_Str, eStringType.Numeric);
        }

        // Checks whether a string is of a certain type.
        // it is public so we can use it in C17_Ex01_05.Program
        public static bool IsStringType(string i_Str, eStringType i_StringType)
        {
            const bool v_IsValidType = true;
            bool IsStringType = true;

            for (int i = 0; (i < i_Str.Length) && IsStringType; i++)
            {
                switch (i_StringType)
                {
                    case eStringType.Numeric:
                        IsStringType = char.IsDigit(i_Str[i]);
                        break;
                    case eStringType.Alphabetic:
                        IsStringType = char.IsLetter(i_Str[i]);
                        break;
                    default:
                        IsStringType = !v_IsValidType;
                        break;
                }
            }

            return IsStringType;
        }        

        // Analyzes an input string and prints the analysis
        private static void analyzeStringAndPrint(string i_Str)
        {
            string strTypeRelatedAnalysis;

            System.Console.WriteLine("===================={0}String Analysis:{0}====================", System.Environment.NewLine);
            System.Console.WriteLine("Input string is {0}a Palindrome!", isPalindromeString(i_Str) ? string.Empty : "not ");
            if (IsStringType(i_Str, eStringType.Numeric))
            {
                strTypeRelatedAnalysis = string.Format("Input numeric string has a digit's average of {0}", calculateDigitsAverage(i_Str));
            }
            else
            {
                strTypeRelatedAnalysis = string.Format("Input alphabetic string contains {0} capital letters", countAmountOfCapitalLetters(i_Str));
            }

            System.Console.WriteLine(strTypeRelatedAnalysis);
        }

        // Counts the amount of capital letters in an alphabetic string
        private static uint countAmountOfCapitalLetters(string i_Str)
        {
            uint upperCaseCharsCounter = 0;

            foreach (char ch in i_Str)
            {
                if (char.IsUpper(ch))
                {
                    upperCaseCharsCounter++;
                }
            }

            return upperCaseCharsCounter;
        }

        // Calculates the digits average of numeric string
        private static float calculateDigitsAverage(string i_NumericStr)
        {
            uint digitsSum = 0;

            foreach (char digit in i_NumericStr)
            {
                digitsSum += uint.Parse(digit.ToString());
            }

            return (float)digitsSum / i_NumericStr.Length;
        }

        // Checks whether a string is a palindrome
        private static bool isPalindromeString(string i_Str)
        {
            bool isPalindrome = true;

            for (int i = 0; (i < (i_Str.Length / 2)) && isPalindrome; i++)
            {
                isPalindrome = i_Str[i] == i_Str[i_Str.Length - 1 - i];
            }

            return isPalindrome;
        }
    }
}
