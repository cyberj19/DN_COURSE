using System;
using StringAnalysis = C17_Ex01_04.Program;

namespace C17_Ex01_05
{
    class Program
    {
        private const uint k_AmountOfDigitsInNumber = 10;
        private const char k_ZeroDigit = '0';
        private const char k_NineDigit = '9';
        private static uint s_BiggestDigit = 9;
        private static uint s_SmallestDigit = 0;
        private static uint s_AmountOfDigitsBiggerThanUnitsDigit = 0;
        private static uint s_AmountOfDigitsSmallerThanUnitsDigit = 0;

        static void Main(string[] args)
        {
            GetNumberAndCalculateStatistics();
        }

        // Gets a number from user and calculates it's statistics
        public static void GetNumberAndCalculateStatistics()
        {
            string inputNumberStr = getInputNumberFromUser();
            calculateAndPrintNumericStatistics(inputNumberStr);
        }

        // Calculates numeric statistics for for an input number and prints the statistics
        private static void calculateAndPrintNumericStatistics(string inputNumberStr)
        {
            сalculateNumericStatistics(inputNumberStr);
            printNumericStatistics();
        }

        // Prints numeric statistics
        private static void printNumericStatistics()
        {
            System.Console.WriteLine("==================={0}Numeric Statistics:{0}===================", System.Environment.NewLine);
            System.Console.WriteLine(
                "The biggest digit is {1}{0}The smallest digit is {2}{0}The amount of digits bigger than units digit is {3}{0}The amount of digits smaller than units digit is {4}",
                System.Environment.NewLine,
               s_BiggestDigit,
               s_SmallestDigit,
               s_AmountOfDigitsBiggerThanUnitsDigit,
               s_AmountOfDigitsSmallerThanUnitsDigit);
        }

        // Calculates numeric statistics
        private static void сalculateNumericStatistics(string inputNumberStr)
        {
            s_BiggestDigit = getBiggestDigitInNumericString(inputNumberStr);
            s_SmallestDigit = getSmallestDigitInNumericString(inputNumberStr);
            s_AmountOfDigitsBiggerThanUnitsDigit = getAmountOfDigitsBiggerThanUnitsDigit(inputNumberStr);
            s_AmountOfDigitsSmallerThanUnitsDigit = getAmountOfDigitsSmallerThanUnitsDigit(inputNumberStr);
        }

        // Counts the amount of digits that are smaller than the units digit
        private static uint getAmountOfDigitsSmallerThanUnitsDigit(string inputNumberStr)
        {
            uint amountOfDigitsSmallerThanUnitsDigitCounter = 0;
            char unitsDigit = inputNumberStr[inputNumberStr.Length - 1];

            foreach (char digit in inputNumberStr)
            {
                if (digit < unitsDigit)
                {
                    amountOfDigitsSmallerThanUnitsDigitCounter++;
                }
            }

            return amountOfDigitsSmallerThanUnitsDigitCounter;
        }

        // Counts the amount of digits that are bigger than the units digit
        private static uint getAmountOfDigitsBiggerThanUnitsDigit(string inputNumberStr)
        {
            uint amountOfDigitsBiggerThanUnitsDigitCounter = 0;
            char unitsDigit = inputNumberStr[inputNumberStr.Length - 1];

            foreach (char digit in inputNumberStr)
            {
                if (digit > unitsDigit)
                {
                    amountOfDigitsBiggerThanUnitsDigitCounter++;
                }
            }

            return amountOfDigitsBiggerThanUnitsDigitCounter;
        }

        // Gets the biggest digit in a numeric string
        private static uint getBiggestDigitInNumericString(string i_NumericStr)
        {
            char maxDigit = k_ZeroDigit;

            foreach (char digit in i_NumericStr)
            {
                if (digit > maxDigit)
                {
                    maxDigit = digit;
                }
            }

            return uint.Parse(maxDigit.ToString());
        }

        // Gets the smallest digit in a numeric string
        private static uint getSmallestDigitInNumericString(string i_NumericStr)
        {
            char minDigit = k_NineDigit;

            foreach (char digit in i_NumericStr)
            {
                if (digit < minDigit)
                {
                    minDigit = digit;
                }
            }

            return uint.Parse(minDigit.ToString());
        }

        // Gets a numeric string from user
        private static string getInputNumberFromUser()
        {
            System.Console.WriteLine("Please enter a number with the length of {0} digits:", k_AmountOfDigitsInNumber);
            string userInputStr = System.Console.ReadLine();

            while (userInputStr.Length != k_AmountOfDigitsInNumber || !StringAnalysis.IsNumericString(userInputStr))
            {
                System.Console.WriteLine("Error: invalid input! {0}Please enter a number with the length of {1} digits:", System.Environment.NewLine, k_AmountOfDigitsInNumber);
                userInputStr = System.Console.ReadLine();
            }

            return userInputStr;
        }
    }
}
