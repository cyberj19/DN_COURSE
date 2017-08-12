using StringAnalysis = C17_Ex01_04.Program;

namespace C17_Ex01_05
{
    class Program
    {
        private const uint k_AmountOfDigitsInNumber = 10;
        private const uint k_NumberOfStatistics = 4;
        private const char k_ZeroDigit = '0';
        private const char k_NineDigit = '9';

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
            System.Console.WriteLine(buildNumericStatisticsString(сalculateNumericStatistics(inputNumberStr)));
        }

        // Prints numeric statistics
        private static string buildNumericStatisticsString(string[] numericStatisticsValues)
        {
            System.Text.StringBuilder numericStatisticsStrBuilder = new System.Text.StringBuilder();

            numericStatisticsStrBuilder.Append(
 @"===================
Numeric Statistics:
===================");

            // todo: not sure if the usage of StringBuilder here is optimal (probably not) also, I wanted to give the array as attribute list but it didn't worked out for me yet
            string numericStatistics = string.Format(
@"
The biggest digit is {0}
The smallest digit is {1}
The amount of digits bigger than the units digit is {2}
The amount of digits smaller than the units digit is {3}",
                numericStatisticsValues);
            numericStatisticsStrBuilder.Append(numericStatistics);

            return numericStatisticsStrBuilder.ToString();
        }

        // Calculates numeric statistics
        private static string[] сalculateNumericStatistics(string inputNumberStr)
        {
            string[] numericStatistics = new string[k_NumberOfStatistics];

            numericStatistics[0] = getBiggestDigitInNumericString(inputNumberStr).ToString(); // todo:  I don't really like this explicit usage of string[] \ uint[] members
            numericStatistics[1] = getSmallestDigitInNumericString(inputNumberStr).ToString();
            numericStatistics[2] = getAmountOfDigitsBiggerThanUnitsDigit(inputNumberStr).ToString();
            numericStatistics[3] = getAmountOfDigitsSmallerThanUnitsDigit(inputNumberStr).ToString();

            return numericStatistics;
        }

        // Counts the amount of digits that are bigger or smaller than the units digit (depends on i_IsBigger boolean parameter)
        private static uint getAmountOfDigitsComparedToUnitsDigit(string inputNumberStr, bool i_IsBigger)
        {
            uint amountOfDigitsComparedToUnitsDigitCounter = 0;
            char unitsDigit = inputNumberStr[inputNumberStr.Length - 1];

            foreach (char digit in inputNumberStr)
            {
                if ((digit > unitsDigit && i_IsBigger) || (digit < unitsDigit && !i_IsBigger))
                {
                    amountOfDigitsComparedToUnitsDigitCounter++;
                }
            }

            return amountOfDigitsComparedToUnitsDigitCounter;
        }

        // Counts the amount of digits that are smaller than the units digit
        private static uint getAmountOfDigitsSmallerThanUnitsDigit(string inputNumberStr)
        {
            const bool v_IsBigger = true;

            return getAmountOfDigitsComparedToUnitsDigit(inputNumberStr, !v_IsBigger);
        }

        // Counts the amount of digits that are bigger than the units digit
        private static uint getAmountOfDigitsBiggerThanUnitsDigit(string inputNumberStr)
        {
            const bool v_IsBigger = true;

            return getAmountOfDigitsComparedToUnitsDigit(inputNumberStr, v_IsBigger);
        }

        // Gets the biggest or smallest digit (depends on i_IsBiggest) in a numeric string
        private static uint getMostDigitInNumericString(string i_NumericStr, bool i_IsBiggest)
        {
            char mostDigit = i_IsBiggest ? k_ZeroDigit : k_NineDigit;

            foreach (char digit in i_NumericStr)
            {
                if (((digit > mostDigit) && i_IsBiggest) || ((digit < mostDigit) && !i_IsBiggest))
                {
                    mostDigit = digit;
                }
            }

            return uint.Parse(mostDigit.ToString());  // todo: Did not verify code yet, but make sure its always a int-str or this might throw an exception
        }

        // Gets the biggest digit in a numeric string
        private static uint getBiggestDigitInNumericString(string i_NumericStr)
        {
            const bool v_IsBiggest = true;

            return getMostDigitInNumericString(i_NumericStr, v_IsBiggest);
        }

        // Gets the smallest digit in a numeric string
        private static uint getSmallestDigitInNumericString(string i_NumericStr)
        {
            const bool v_IsBiggest = true;

            return getMostDigitInNumericString(i_NumericStr, !v_IsBiggest);
        }

        // Gets a numeric string from user
        private static string getInputNumberFromUser()
        {
            string userInputStr = string.Empty;

            while ((userInputStr.Length != k_AmountOfDigitsInNumber) || !StringAnalysis.IsNumericString(userInputStr))
            {
                System.Console.WriteLine("Please enter a number with the length of {0} digits:", k_AmountOfDigitsInNumber);
                userInputStr = System.Console.ReadLine();
            }

            return userInputStr;
        }
    }
}
