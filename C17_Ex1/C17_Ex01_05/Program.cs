using System;
using StringAnalysis = C17_Ex01_04.Program;

namespace C17_Ex01_05
{
    class Program
    {
        const uint k_AmountOfDigitsInNumber = 10;

        static void Main(string[] args)
        {
            GetNumberAndCalculateStatistics();
        }

        public static void GetNumberAndCalculateStatistics()
        {
            string inputNumberStr = getInputNumberFromUser();
            calculateAndPrintNumericStatistics(inputNumberStr);
        }

        private static void calculateAndPrintNumericStatistics(string inputNumberStr)
        {
            printNumericStatistics(сalculateNumericStatistics(inputNumberStr));
        }

        private static void printNumericStatistics(NumericStatistics i_NumericStatistics)
        {
            System.Console.WriteLine("==================={0}Numeric Statistics:{0}===================", System.Environment.NewLine);
            System.Console.WriteLine(
                "The biggest digit is {1}{0}The smallest digit is {2}{0}The amount of digits bigger than units digit is {3}{0}The amount of digits smaller than units digit is {4}",
                System.Environment.NewLine,
                i_NumericStatistics.BiggestDigit,
                i_NumericStatistics.SmallestDigit,
                i_NumericStatistics.AmountOfDigitsBiggerThanUnitsDigit,
                i_NumericStatistics.AmountOfDigitsSmallerThanUnitsDigit);
        }

        private static NumericStatistics сalculateNumericStatistics(string inputNumberStr)
        {
            NumericStatistics o_NumericStatistics;
            o_NumericStatistics.BiggestDigit = getBiggestDigitInNumericString(inputNumberStr);
            o_NumericStatistics.SmallestDigit = getSmallestDigitInNumericString(inputNumberStr);
            o_NumericStatistics.AmountOfDigitsBiggerThanUnitsDigit = getAmountOfDigitsBiggerThanUnitsDigit(inputNumberStr);
            o_NumericStatistics.AmountOfDigitsSmallerThanUnitsDigit = getAmountOfDigitsSmallerThanUnitsDigit(inputNumberStr);
            return o_NumericStatistics;
        }

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

        private static uint getBiggestDigitInNumericString(string i_NumericStr)
        {
            char maxDigit = '0';

            foreach (char digit in i_NumericStr)
            {
                if (digit > maxDigit)
                {
                    maxDigit = digit;
                }
            }

            return uint.Parse(maxDigit.ToString());
        }

        private static uint getSmallestDigitInNumericString(string i_NumericStr)
        {
            char minDigit = '9';

            foreach (char digit in i_NumericStr)
            {
                if (digit < minDigit)
                {
                    minDigit = digit;
                }
            }

            return uint.Parse(minDigit.ToString());
        }

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
        
        struct NumericStatistics
        {
            public uint BiggestDigit;
            public uint SmallestDigit;
            public uint AmountOfDigitsBiggerThanUnitsDigit; 
            public uint AmountOfDigitsSmallerThanUnitsDigit; 
        }
    }
}
