namespace C17_Ex01_04
{
    public class Program
    {
        private const uint k_NumOfCharsInString = 10;

        static void Main(string[] args)
        {
            AnalyzeStringFromUser();
        }

        // Getting an input string from user and analyzes it
        public static void AnalyzeStringFromUser()
        {
            analyzeStringAndPrint(getStringFromUser());
        }
        
        // Getting a valid string from user
        private static string getStringFromUser()
        {
            string userInputStr = string.Empty;

            while ((userInputStr.Length != k_NumOfCharsInString) || !isAlphabeticOrNumericString(userInputStr))
            {
                System.Console.WriteLine("Please enter a numeric or an alphabetic string with the length of {0} characters:", k_NumOfCharsInString);
                userInputStr = System.Console.ReadLine();
            }

            return userInputStr;
        }

        // Checks whether a string contains exclusively numeric or alphabetic characters but not both (not alphanumric!)
        private static bool isAlphabeticOrNumericString(string i_Str)
        {
            return IsAlphabeticString(i_Str) || IsNumericString(i_Str);
        }

        // Checks whether a string contains only alphabetic characters
        public static bool IsAlphabeticString(string i_Str)
        {
            bool isAlphabeticString = true;

            for(int i = 0; (i < i_Str.Length) && isAlphabeticString; i++)
            {
                isAlphabeticString = char.IsLetter(i_Str[i]);
            }

            return isAlphabeticString;
        }

        // Checks whether a string contains only numeric characters
        public static bool IsNumericString(string i_Str)
        {
            bool isNumericString = true;

            for (int i = 0; (i < i_Str.Length) && isNumericString; i++)
            {
                isNumericString = char.IsDigit(i_Str[i]);
            }

            return isNumericString;
        }
        
        // Analyzes an input string and prints the analysis
        private static void analyzeStringAndPrint(string i_Str)
        {
            System.Console.WriteLine("===================={0}String Analysis:{0}====================", System.Environment.NewLine);
            System.Console.WriteLine("Input string is {0}a Palindrome!", isPalindromeString(i_Str) ? string.Empty : "not ");
            if (IsNumericString(i_Str))
            {
                System.Console.WriteLine("Input numeric string has a digit's average of {0}", calculateDigitsAverage(i_Str));
            }
            else
            {
                System.Console.WriteLine("Input alphabetic string contains {0} capital letters", countAmountOfCapitalLetters(i_Str));
            }
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
