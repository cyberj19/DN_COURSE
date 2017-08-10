namespace C17_Ex01_01
{
    class Program
    {        
        private const uint k_AmountNumbersToRecv = 4;
        private const int k_BinaryBase = 2;
        private const char k_ZeroChar = '0';
        private const char k_OneChar = '1';
        
        static void Main(string[] args)
        {
            getNumbersFromUserAndPrintBinaryInformation();
        }

        // recv positive integer number from the user. In case of bad numbers, will ask for numbers again.
        private static uint[] recvPositiveIntegerNumbersFromUser(uint i_AmountOfNumbersToRecv)
        {
            uint[] numbersReceivedArr = new uint[i_AmountOfNumbersToRecv];
            uint numSuccessfulParsedNumbers = 0;

            System.Console.WriteLine("Please Insert {0} Positive Integer Numbers:", i_AmountOfNumbersToRecv);
            while (numSuccessfulParsedNumbers < i_AmountOfNumbersToRecv)
            {
                string currRawUserInput = System.Console.ReadLine();
                uint currUserInputParsed;

                if (!uint.TryParse(currRawUserInput, out currUserInputParsed))
                {
                    System.Console.WriteLine("Bad input Received. Please insert a positive integer number:");
                    continue;
                }

                numbersReceivedArr[numSuccessfulParsedNumbers] = currUserInputParsed;
                numSuccessfulParsedNumbers++;
            }

            return numbersReceivedArr;
        }
        
        // converts a uint number to it's binary representation (string)
        private static string convertUIntToBinaryStr(uint i_Number)
        {
            return System.Convert.ToString(i_Number, k_BinaryBase);
        }

        // Checks whether the number's digits are in a certain order.
        // will check from right to left instead of left to right (So Asc and Desc will be the opposite of what they are suppose to be when comparing
        // old digit to curr digit).
        private static bool isNumDigitsInOrder(bool i_IsAscRequired, int i_Num)
        {
            bool isInOrder = i_Num != 0;
            int lastDigitChecked = i_Num % 10;

            i_Num /= 10;
            while (isInOrder && (i_Num > 0))
            {
                int currDigit = i_Num % 10;
                i_Num /= 10;

                isInOrder = (i_IsAscRequired && (currDigit < lastDigitChecked)) || (!i_IsAscRequired && (lastDigitChecked < currDigit));
            }

            return isInOrder;
        }

        // checks whether the number's digits are in ascending order
        private static bool isAscendingDigits(int i_Num)
        {
            const bool v_IsAscendingOrder = true;

            return isNumDigitsInOrder(v_IsAscendingOrder, i_Num);
        }

        // checks whether the number's digits are in descending order
        private static bool isDescendingDigits(int i_Num)
        {
            const bool v_IsAscendingOrder = true;

            return isNumDigitsInOrder(!v_IsAscendingOrder, i_Num);
        }
        
        private static string[] uintArrToBinaryStrArray(uint[] i_NumArr)
        {
            string[] binArr = new string[i_NumArr.Length];

            for (int i = 0; i < i_NumArr.Length; i++)
            {
                binArr[i] = convertUIntToBinaryStr(i_NumArr[i]);
            }

            return binArr;
        }

        private static void printStrArr(string[] i_ArrToPrint)
        {
            for (int i = 0; i < i_ArrToPrint.Length; i++)
            {
                System.Console.WriteLine("{0}. {1}", i + 1, i_ArrToPrint[i]);
            }
        }

        private static double calcPositiveNumArrAvg(uint[] i_NumArr)
        {
            double sum = 0.0;

            for (int i = 0; i < i_NumArr.Length; i++)
            {
                sum += i_NumArr[i];
            }

            return sum / i_NumArr.Length;
        }

        private static void getNumPositiveArrOrderInfo(uint[] i_Arr, out uint o_AmountAscendingNumbers, out uint o_AmountDescendingNumbers)
        {
            uint amountAscendingNumbers = 0;
            uint amountDescendingNumbers = 0;

            for (int i = 0; i < i_Arr.Length; i++)
            {
                if (isAscendingDigits((int)i_Arr[i]))
                {
                    amountAscendingNumbers++;
                }
                else if (isDescendingDigits((int)i_Arr[i]))
                {
                    amountDescendingNumbers++;
                }
            }

            o_AmountAscendingNumbers = amountAscendingNumbers;
            o_AmountDescendingNumbers = amountDescendingNumbers;
        }

        private static double calcStringArraySingleStrLengthAvg(string[] i_StrArr)
        {
            double lengthSum = 0.0;

            for (int i = 0; i < i_StrArr.Length; i++)
            {
                lengthSum += i_StrArr[i].Length;
            }

            return lengthSum / i_StrArr.Length; 
        }

        // get 'k_AmountNumbersToRecv' amount of numbers from the user, and print status information about the group of numbers.
        private static void getNumbersFromUserAndPrintBinaryInformation()
        {
            uint[] numbersReceived = recvPositiveIntegerNumbersFromUser(k_AmountNumbersToRecv);
            string[] numbersReceivedAsBinStrArr = uintArrToBinaryStrArray(numbersReceived);
            uint amountAscendingNumbers;
            uint amountDescendingNumbers;
            double numbersAvg = calcPositiveNumArrAvg(numbersReceived) / k_AmountNumbersToRecv;
            double numbersBinaryDigitsAvg = calcStringArraySingleStrLengthAvg(numbersReceivedAsBinStrArr);

            getNumPositiveArrOrderInfo(numbersReceived, out amountAscendingNumbers, out amountDescendingNumbers);
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