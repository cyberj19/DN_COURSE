using System; //todo: delete this

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
            //todo: Should start with var decleartion.
            //todo: 2# if you're using Read line in a loop anyway, why are you doing it outside aswell?
            //todo: Why not "WriteLine" before the loop and use only 1 read line inside the loop?
            System.Console.WriteLine("Please enter a numeric or an alphabetic string with the length of {0} characters:", k_NumOfCharsInString);
            string userInputStr = System.Console.ReadLine();

            //todo: For readablitiy, please use '(' ')' between 2 different conditions when one of the conditions is more than 1 word
            //todo: (When using != < > etc')
            while (userInputStr.Length != k_NumOfCharsInString || !isAlphabeticOrNumericString(userInputStr))
            {
                System.Console.WriteLine("Error: invalid string! {0}Please enter a numeric or an alphabetic string with the length of {1} characters:", System.Environment.NewLine, k_NumOfCharsInString);
                userInputStr = System.Console.ReadLine();
            }

            return userInputStr;
        }

        //todo: It's called Alphanumeric string :)
        // Checks whether a string contains exclusively numeric or alphabetic characters but not both
        private static bool isAlphabeticOrNumericString(string i_Str)
        {
            return IsAlphabeticString(i_Str) || IsNumericString(i_Str);
        }

        // Checks whether a string contains only alphabetic characters
        public static bool IsAlphabeticString(string i_Str)
        {
            bool isAlphabeticString = true;

            //todo: we didnt learn foreach yet, should rethink. perhaps use for loop
            foreach (char ch in i_Str)
            {
                //todo: he states do not use "=false" or "=true" on any variable inside an if! 
                //todo: You could do instead isAlphabeticString = char.IsLetter(ch)
                //todo: and instead check 'isAlphabeticString' for exiting the loop
                if (!char.IsLetter(ch))
                {
                    isAlphabeticString = false;
                    break;
                }
            }

            return isAlphabeticString;
        }

        // Checks whether a string contains only numeric characters
        public static bool IsNumericString(string i_Str)
        {
            bool isNumericString = true;

            //todo: Same comment as above function. Also u use same code twice. Consider copying my method in First program "isNumDigitsInOrder"
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
        private static void analyzeStringAndPrint(string i_Str)
        {
            System.Console.WriteLine("===================={0}String Analysis:{0}====================", System.Environment.NewLine);
            System.Console.WriteLine("Input string is {0}a Palindrome!", isPalindromeString(i_Str) ? string.Empty : "not ");
            //why blank line? No reason. delete the following line

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
        private static bool isPalindromeString(string i_str)
        {
            //todo: Not goot names. i do not understand what the variables do. If i dont understand, The "Bodek" Wont understand aswell. IDX?
            uint leftIdx = 0;
            uint rightIdx = (uint)i_str.Length - 1;
            bool isPalindrome = true;

            //todo: Why using 2 variables? Why not just count with i from 0 to len/2? Str[i] == Str[length - i - 1] ?
            while (rightIdx > leftIdx)
            {
                //todo: Same comment as above. If that u insert to a boolean
                //todo: #2 why are u casting to int?
                if (i_str[(int)rightIdx] != i_str[(int)leftIdx])
                {
                    isPalindrome = false;
                    break;
                }

                rightIdx--;
                leftIdx++;
            }

            return isPalindrome;
        }
    }
}
