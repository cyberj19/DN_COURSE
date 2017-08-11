using System;

namespace C17_Ex01_04
{
    class Program
    {
        const uint k_NumOfCharsInString = 10;

        static void Main(string[] args)
        {
            AnalyzeStringFromUser();
        }

        // Getting an input string from user and analyzes it
        public static void AnalyzeStringFromUser()
        {
            string userInputStr = getStringFromUser();
            analyzeString(userInputStr);
        }
        
        // Getting a valid string from user
        private static string getStringFromUser()
        {
            System.Console.WriteLine("Please enter a numeric or an alphabetic string with the length of {0} characters:", k_NumOfCharsInString);
            string userInputStr = System.Console.ReadLine();
            while (userInputStr.Length != k_NumOfCharsInString || !isAlphabeticOrNumericString(userInputStr))
            {
                System.Console.WriteLine("Error: invalid string! {0}Please enter a numeric or an alphabetic string with the length of {1} characters:", System.Environment.NewLine, k_NumOfCharsInString);
                userInputStr = System.Console.ReadLine();
            }

            return userInputStr;
        }

        // Checks whether a string contains exclusively numeric or alphabetic characters but not both
        private static bool isAlphabeticOrNumericString(string i_Str)
        {
            return IsAllLetters(i_Str) || IsAllDigits(i_Str);
        }

        // Checks whether a string contains only alphabetic characters
        public static bool IsAllLetters(string i_Str)
        {
            bool isAlphabeticString = true;
            foreach (char ch in i_Str)
            {
                if (!char.IsLetter(ch))
                {
                    isAlphabeticString = false;
                    break;
                }
            }

            return isAlphabeticString;
        }

        // Checks whether a string contains only numeric characters
        private static bool IsAllDigits(string i_Str)
        {
            bool isNumericString = true;
            foreach (char ch in i_Str)
            {
                if (!char.IsDigit(ch))
                {
                    isNumericString = false;
                    break;
                }
            }

            return isNumericString;
        }
        
        // Analyzes an input string and prints the analysis
        private static void analyzeString(string i_Str)
        {
            System.Console.WriteLine("===================={0}String Analysis:{0}====================", System.Environment.NewLine);
            bool v_isPalindrome = isPalindrome(i_Str);
            System.Console.WriteLine("Input string is {0}a Palindrome!", v_isPalindrome ? string.Empty : "not ");
            bool isNumeric = IsAllDigits(i_Str);
            if (isNumeric)
            {
                float digitsAverage = calculateDigitsAverage(i_Str);                 // digits average

                System.Console.WriteLine("Input numeric string has a digit's average of {0}", digitsAverage);
            }
            else
            { // is not numeric
                uint amountOfCapitalLetters = countAmountOfCapitalLetters(i_Str);                 // num of capital letters

                System.Console.WriteLine("Input alphabetic string contains {0} capital letters", amountOfCapitalLetters);
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
        private static bool isPalindrome(string i_str)
        {
            uint leftIdx = 0;
            uint rightIdx = (uint)i_str.Length - 1;
            bool v_isPalindrome = true;

            while (rightIdx > leftIdx)
            {
                if (i_str[(int)rightIdx] != i_str[(int)leftIdx])
                {
                    v_isPalindrome = false;
                    break;
                }

                rightIdx--;
                leftIdx++;
            }

            return v_isPalindrome;
        }
    }
}
