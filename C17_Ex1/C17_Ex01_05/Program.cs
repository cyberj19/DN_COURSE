using StringAnalysis = C17_Ex01_04.Program;

namespace C17_Ex01_05
{
    class Program
    {
        private const uint k_AmountOfDigitsInNumber = 10;
        private const uint k_NumberOfSections = 4;
        private const char k_ZeroDigit = '0';
        private const char k_NineDigit = '9';

        static void Main(string[] args)
        {
            getNumberAndCalculateAndPrintStatistics();
        }

        // Gets a number from user, calculates it's statistics then prints the statistics
        private static void getNumberAndCalculateAndPrintStatistics() 
        {
            string inputNumberStr = getInputNumberFromUser();

            calculateAndPrintNumericStatistics(inputNumberStr);
        }

        // Calculates numeric statistics for for an input number and prints the statistics
        private static void calculateAndPrintNumericStatistics(string i_InputNumberStr)
        {
            string[] numericStatisticsValues = сalculateNumericStatistics(i_InputNumberStr);
            string numericStatisticsReportStr = buildNumericStatisticsReportString(numericStatisticsValues);

            System.Console.WriteLine(numericStatisticsReportStr);
        }

        // Prints numeric statistics
        private static string buildNumericStatisticsReportString(string[] i_NumericStatisticsValues)
        {
            System.Text.StringBuilder numericStatisticsStrBuilder = new System.Text.StringBuilder();

            numericStatisticsStrBuilder.AppendFormat("==================={0}", System.Environment.NewLine);
            numericStatisticsStrBuilder.AppendFormat("Numeric Statistics:{0}", System.Environment.NewLine);
            numericStatisticsStrBuilder.AppendFormat("==================={0}", System.Environment.NewLine);
            numericStatisticsStrBuilder.AppendFormat("The biggest digit is {1}{0}", System.Environment.NewLine, i_NumericStatisticsValues[0]);
            numericStatisticsStrBuilder.AppendFormat("The smallest digit is {1}{0}", System.Environment.NewLine, i_NumericStatisticsValues[1]);
            numericStatisticsStrBuilder.AppendFormat("The amount of digits bigger than the units digit is {1}{0}", System.Environment.NewLine, i_NumericStatisticsValues[2]);
            numericStatisticsStrBuilder.AppendFormat("The amount of digits smaller than the units digit is {1}{0}", System.Environment.NewLine, i_NumericStatisticsValues[3]);

            return numericStatisticsStrBuilder.ToString();
        }

        // Calculates numeric statistics
        private static string[] сalculateNumericStatistics(string i_InputNumberStr)
        {
            string[] NumericStatisticsSections = new string[k_NumberOfSections];

            NumericStatisticsSections[0] = getBiggestDigitInNumericString(i_InputNumberStr).ToString();
            NumericStatisticsSections[1] = getSmallestDigitInNumericString(i_InputNumberStr).ToString();
            NumericStatisticsSections[2] = getAmountOfDigitsBiggerThanUnitsDigit(i_InputNumberStr).ToString();
            NumericStatisticsSections[3] = getAmountOfDigitsSmallerThanUnitsDigit(i_InputNumberStr).ToString();

            return NumericStatisticsSections;
        }

        // Counts the amount of digits that are bigger or smaller than the units digit (depends on i_IsBigger boolean parameter)
        private static uint getAmountOfDigitsComparedToUnitsDigit(string i_InputNumberStr, bool i_IsBiggerOperation)
        {
            uint amountOfDigitsComparedToUnitsDigitCounter = 0;
            char unitsDigit = i_InputNumberStr[i_InputNumberStr.Length - 1];

            foreach (char digit in i_InputNumberStr)
            { 
                if (((digit > unitsDigit) && i_IsBiggerOperation) || ((digit < unitsDigit) && !i_IsBiggerOperation))
                {
                    amountOfDigitsComparedToUnitsDigitCounter++;
                }
            }

            return amountOfDigitsComparedToUnitsDigitCounter;
        }

        // Counts the amount of digits that are smaller than the units digit
        private static uint getAmountOfDigitsSmallerThanUnitsDigit(string i_InputNumberStr)
        {
            const bool v_IsBiggerOperation = true;

            return getAmountOfDigitsComparedToUnitsDigit(i_InputNumberStr, !v_IsBiggerOperation);
        }

        // Counts the amount of digits that are bigger than the units digit
        private static uint getAmountOfDigitsBiggerThanUnitsDigit(string i_InputNumberStr)
        {
            const bool v_IsBiggerOperation = true;

            return getAmountOfDigitsComparedToUnitsDigit(i_InputNumberStr, v_IsBiggerOperation);
        }

        // Gets the biggest or smallest digit (depends on i_IsBiggest) in a numeric string
        // We assume that 'i_NumericStr' is always a int-str, so that 'mostDigit' will always be parsed successfully
        private static uint getMostDigitInNumericString(string i_NumericStr, bool i_IsBiggestOperation)
        {
            char mostDigit = i_IsBiggestOperation ? k_ZeroDigit : k_NineDigit;

            foreach (char digit in i_NumericStr)
            {
                if (((digit > mostDigit) && i_IsBiggestOperation) || ((digit < mostDigit) && !i_IsBiggestOperation))
                {
                    mostDigit = digit;
                }
            }

            return uint.Parse(mostDigit.ToString());
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
            bool isValidInput;

            System.Console.WriteLine("Please enter a natural number with the length of {0} digits:", k_AmountOfDigitsInNumber);
            do
            {
                userInputStr = System.Console.ReadLine();
                isValidInput = (userInputStr.Length == k_AmountOfDigitsInNumber) && StringAnalysis.IsNumericString(userInputStr);
                if (!isValidInput)
                {
                    System.Console.WriteLine("Invalid input! Please try again:");
                }
            }
            while (!isValidInput);

            return userInputStr;
        }
    }
}
