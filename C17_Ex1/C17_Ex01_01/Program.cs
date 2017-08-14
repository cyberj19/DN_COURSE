namespace C17_Ex01_01
{
    class Program
    {
        private enum eOrderType
        {
            Ascending,
            Descending,
        }

        private const uint k_AmountNumbersToRecv = 4;
        private const uint k_NumDigitsPerNum = 4;
        private const int k_BinaryBase = 2;
        private const char k_ZeroChar = '0';
        private const char k_OneChar = '1';
        
        static void Main(string[] args)
        {
            getNumbersFromUserAndPrintBinaryInformation();
        }

        // Receive positive integer number from the user. In case of bad numbers, will ask for numbers again.
        private static uint[] recvPositiveIntegerNumbersFromUser(uint i_AmountOfNumbersToRecv, uint i_NumDigitsPerNum)
        {
            uint[] numbersReceivedArr = new uint[i_AmountOfNumbersToRecv];
            uint numSuccessfulParsedNumbers = 0;

            System.Console.WriteLine("Please insert {0} positive integer numbers with {1} digits:", i_AmountOfNumbersToRecv, i_NumDigitsPerNum);
            while (numSuccessfulParsedNumbers < i_AmountOfNumbersToRecv)
            {
                string currRawUserInput = System.Console.ReadLine();
                uint currUserInputParsed;

                if ((!uint.TryParse(currRawUserInput, out currUserInputParsed)) || (i_NumDigitsPerNum != (uint)currRawUserInput.Length))
                {
                    System.Console.WriteLine("Bad input received. Please insert again:");
                    continue;
                }

                numbersReceivedArr[numSuccessfulParsedNumbers] = currUserInputParsed;
                numSuccessfulParsedNumbers++;
            }

            return numbersReceivedArr;
        }
        
        // Converts a uint number to it's binary representation (string)
        private static string convertUIntToBinaryStr(uint i_Number)
        {
            System.Text.StringBuilder binaryStrBuilder = new System.Text.StringBuilder();

            if (i_Number == 0)
            {
                binaryStrBuilder.Append(k_ZeroChar);
            }

            while (i_Number > 0)
            {
                char charToAdd;

                if ((i_Number % k_BinaryBase) == 0)
                {
                    charToAdd = k_ZeroChar;
                }
                else
                {
                    charToAdd = k_OneChar;
                }

                binaryStrBuilder.Insert(0, charToAdd);
                i_Number /= k_BinaryBase;
            }

            return binaryStrBuilder.ToString();
        }

        // Checks whether the number's digits are in a certain order.
        // will check from right to left instead of left to right (So Asc and Desc will be the opposite of what they are suppose to be when comparing
        // old digit to curr digit).
        private static bool isNumDigitsInOrder(eOrderType i_OrderType, int i_Num)
        {
            const bool v_IsValidOrderType = true;
            bool isInOrder = i_Num != 0; 
            int lastDigitChecked = i_Num % 10;

            i_Num /= 10;
            while (isInOrder && (i_Num > 0))
            {
                int currDigit = i_Num % 10;

                i_Num /= 10;
                switch (i_OrderType)
                {
                    case eOrderType.Ascending:
                        isInOrder = currDigit < lastDigitChecked;
                        break;
                    case eOrderType.Descending:
                        isInOrder = lastDigitChecked < currDigit;
                        break;
                    default:
                        isInOrder = !v_IsValidOrderType;
                        break;
                }

                lastDigitChecked = currDigit;
            }

            return isInOrder;
        }

        // Checks whether the number's digits are in ascending order
        private static bool isAscendingDigits(int i_Num)
        {
            return isNumDigitsInOrder(eOrderType.Ascending, i_Num);
        }

        // Checks whether the number's digits are in descending order
        private static bool isDescendingDigits(int i_Num)
        {
            return isNumDigitsInOrder(eOrderType.Descending, i_Num);
        }
        
        // Converts a uint array to a Binary string array
        private static string[] uintArrToBinaryStrArray(uint[] i_NumArr)
        {
            string[] binArr = new string[i_NumArr.Length];

            for (int i = 0; i < i_NumArr.Length; i++)
            {
                binArr[i] = convertUIntToBinaryStr(i_NumArr[i]);
            }

            return binArr;
        }

        // Prints string array
        private static void printStrArr(string[] i_ArrToPrint)
        {
            for (int i = 0; i < i_ArrToPrint.Length; i++)
            {
                System.Console.WriteLine("{0}. {1}", i + 1, i_ArrToPrint[i]);
            }
        }

        // Calculates average from a positive numbers array
        private static double calcPositiveNumArrAvg(uint[] i_NumArr)
        {
            double sum = 0.0;

            for (int i = 0; i < i_NumArr.Length; i++)
            {
                sum += i_NumArr[i];
            }

            return sum / i_NumArr.Length;
        }

        // Get information about order in an array (Amount of ascending and descending)
        private static void getNumPositiveArrOrderInfo(uint[] i_Arr, uint i_MaxNumDigits, out uint o_AmountAscendingNumbers, out uint o_AmountDescendingNumbers)
        {
            uint amountAscendingNumbers = 0;
            uint amountDescendingNumbers = 0;

            for (int i = 0; i < i_Arr.Length; i++)
            {
                bool isAboveTwoDigits = i_MaxNumDigits > 2;
                bool isLessThanMaxNumberWithoutTwoDigit = i_Arr[i] < System.Math.Pow(10, i_MaxNumDigits - 2);
                bool isLessThanMaxNumberWithoutOneDigits = i_Arr[i] < System.Math.Pow(10, i_MaxNumDigits - 1);
                bool shouldCheckForDescendingDigits = !(isLessThanMaxNumberWithoutOneDigits && isAboveTwoDigits);
                
                // If max number of digits is 4, then every number below 100 cannot be ascending/desending (starts with 2 zeroes or more)
                if (isAboveTwoDigits && isLessThanMaxNumberWithoutTwoDigit)
                {
                    continue;
                }
                
                if (isAscendingDigits((int)i_Arr[i]))
                {
                    amountAscendingNumbers++;
                }
                else if (shouldCheckForDescendingDigits && isDescendingDigits((int)i_Arr[i]))
                {
                    // About 'shouldCheckForDescendingDigits' : if max number is 9999, 0999 Cannot be a descending number!. 
                    // 3210 would be the last descending number, but our current problem is the '0' at the beginning.
                    amountDescendingNumbers++;
                }
            }

            o_AmountAscendingNumbers = amountAscendingNumbers;
            o_AmountDescendingNumbers = amountDescendingNumbers;
        }

        // Calculates the average of strings length
        private static double calcAvgStringLengthInArray(string[] i_StrArr)
        {
            double lengthSum = 0.0;

            for (int i = 0; i < i_StrArr.Length; i++)
            {
                lengthSum += i_StrArr[i].Length;
            }

            return lengthSum / i_StrArr.Length; 
        }

        // Gets 'k_AmountNumbersToRecv' amount of numbers from the user, and prints status information about the group of numbers
        private static void getNumbersFromUserAndPrintBinaryInformation()
        {
            uint[] numbersReceived = recvPositiveIntegerNumbersFromUser(k_AmountNumbersToRecv, k_NumDigitsPerNum);
            string[] numbersReceivedAsBinStrArr = uintArrToBinaryStrArray(numbersReceived);
            uint amountAscendingNumbers;
            uint amountDescendingNumbers;
            double numbersAvg = calcPositiveNumArrAvg(numbersReceived);
            double numbersBinaryDigitsAvg = calcAvgStringLengthInArray(numbersReceivedAsBinStrArr);

            getNumPositiveArrOrderInfo(numbersReceived, k_NumDigitsPerNum, out amountAscendingNumbers, out amountDescendingNumbers);
            System.Console.WriteLine("Numbers binary format:");
            printStrArr(numbersReceivedAsBinStrArr);
            System.Console.WriteLine(
                "General Information:{0} Avg '1/0': {1} {0} Ascending Numbers Count: {2} {0} Descending Numbers Count: {3} {0} Avg Of Numbers: {4}",
                System.Environment.NewLine,
                numbersBinaryDigitsAvg,
                amountAscendingNumbers,
                amountDescendingNumbers,
                numbersAvg);
        }
    }
}