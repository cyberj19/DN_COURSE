using System;
using StringAnalysis = C17_Ex01_04.Program;

namespace C17_Ex01_05
{
    class Program
    {
        const uint k_AmountOfDigitsInNumber = 10;
        const char k_zeroDigit = '0';
        const char k_nineDigit = '9';

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
            printNumericStatistics(сalculateNumericStatistics(inputNumberStr));
        }

        // Prints numeric statistics
        private static void printNumericStatistics(NumericStatistics i_NumericStatistics)
        {
            System.Console.WriteLine("==================={0}Numeric Statistics:{0}===================", System.Environment.NewLine);
            System.Console.WriteLine(
                "The biggest digit is {1}{0}The smallest digit is {2}{0}The amount of digits bigger than units digit is {3}{0}The amount of digits smaller than units digit is {4}",
                System.Environment.NewLine,
                i_NumericStatistics.m_BiggestDigit,
                i_NumericStatistics.m_SmallestDigit,
                i_NumericStatistics.m_AmountOfDigitsBiggerThanUnitsDigit,
                i_NumericStatistics.m_AmountOfDigitsSmallerThanUnitsDigit);
        }

        // Calculates numeric statistics
        private static NumericStatistics сalculateNumericStatistics(string inputNumberStr)
        {
            NumericStatistics o_NumericStatistics;

            o_NumericStatistics.m_BiggestDigit = getBiggestDigitInNumericString(inputNumberStr);
            o_NumericStatistics.m_SmallestDigit = getSmallestDigitInNumericString(inputNumberStr);
            o_NumericStatistics.m_AmountOfDigitsBiggerThanUnitsDigit = getAmountOfDigitsBiggerThanUnitsDigit(inputNumberStr);
            o_NumericStatistics.m_AmountOfDigitsSmallerThanUnitsDigit = getAmountOfDigitsSmallerThanUnitsDigit(inputNumberStr);

            return o_NumericStatistics;
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
            char maxDigit = k_zeroDigit;

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
            char minDigit = k_nineDigit;

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
        
        // a struct to hold the numeric statistics
        struct NumericStatistics
        {
            public uint m_BiggestDigit;
            public uint m_SmallestDigit;
            public uint m_AmountOfDigitsBiggerThanUnitsDigit; 
            public uint m_AmountOfDigitsSmallerThanUnitsDigit; 
        }
    }
}
