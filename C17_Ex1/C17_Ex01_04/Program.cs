

using System;

namespace C17_Ex01_03
{
    class Program
    {
        static void Main(string[] args)
        {
            AnalyzeStringFromUser();

        }

        public static void AnalyzeStringFromUser()
        {
            string userInputStr = getStringFromUserAndAnalyze();
            analyzeString(userInputStr);
        }


        private static string getStringFromUserAndAnalyze()
        {
            const uint k_NumOfCharsInString = 10;
            System.Console.WriteLine("Please enter a string with the length of {0} characters:", k_NumOfCharsInString);
            string userInputStr = System.Console.ReadLine();
            while (userInputStr.Length != k_NumOfCharsInString || !isValidString(userInputStr))
            {
                System.Console.WriteLine("Error: invalid string! {0}Please enter a string with the length of {1} characters:", System.Environment.NewLine ,k_NumOfCharsInString);
                userInputStr = System.Console.ReadLine();
            }
            return userInputStr;
        }


        private static bool isValidString(string i_Str)
        {
            bool v_IsValidString = true;
            if(!IsAllLetters(i_Str) && !IsAllDigits(i_Str))
            {
                v_IsValidString = false;
            }
            return v_IsValidString;
        }



        public static bool IsAllLetters(string i_Str)
        {
            bool v_IsAlphabeticString = true;
            foreach (char ch in i_Str)
            {
                if (!Char.IsLetter(ch))
                {
                    v_IsAlphabeticString = false;
                    break;
                }
            }
            return v_IsAlphabeticString;
        }

        private static bool IsAllDigits(string i_Str)
        {
            bool v_IsNumericString = true;
            foreach (char ch in i_Str)
            {
                if (!Char.IsDigit(ch))
                {
                    v_IsNumericString = false;
                    break;
                }
            }
            return v_IsNumericString;
        }

        private static void analyzeString(string i_Str)
        {
            System.Console.WriteLine("String Analysis:");
            bool v_isPalindrome = isPalindrome(i_Str);
            System.Console.WriteLine("Input string is " + ((v_isPalindrome)?"":"not ") + "a Palindrome!");
            int o_NumberFromString;
            bool isNumeric = int.TryParse(i_Str, out o_NumberFromString);
            if (isNumeric)
            {
                uint digitsAverage = calculateDigitsAverage(o_NumberFromString);                 // digits average

                System.Console.WriteLine("Input numeric string has a digit's average of {0}", digitsAverage);
            }
            else // is not numeric
            {
                uint amountOfCapitalLetters = countAmountOfCapitalLetters(i_Str);                 // num of capital letters

                System.Console.WriteLine("Input alphabetic string contains {0} capital letters", amountOfCapitalLetters);

            }
        }

        private static uint countAmountOfCapitalLetters(string i_Str)
        {
            uint upperCaseCharsCounter = 0;
            foreach (char ch in i_Str)
            {
                if (Char.IsUpper(ch))
                {
                    upperCaseCharsCounter++;
                }
            }
            return upperCaseCharsCounter;
        }
        
        private static uint calculateDigitsAverage(int i_Number)
        {
            uint digitsCounter = 0;
            uint digitsSum = 0;

            for (int number = i_Number; number > 0; number /= 10)
            {
                digitsCounter++;
                digitsSum += (uint)number % 10;
            }
            return digitsSum / digitsCounter;
        }



        private static bool isPalindrome(string i_str)
        {
            uint leftIdx = 0;
            uint rightIdx = (uint)i_str.Length - 1;
            bool v_isPalindrome = true;

            while(rightIdx > leftIdx)
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
