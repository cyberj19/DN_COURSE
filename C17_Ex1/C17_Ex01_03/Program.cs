using SimpleHourGlass = C17_Ex01_02.Program; 

namespace C17_Ex01_03
{
    class Program
    {
        private const char k_HourGlassChar = '*';

        static void Main(string[] args)
        {
            getCustomLengthAndPrintHourGlass();
        }

        // Prints an hour-glass by custom size it gets from user input 
        private static void getCustomLengthAndPrintHourGlass()
        {
            string hourGlassStr = SimpleHourGlass.GenerateHourGlassStr(getCustomLengthOfHourGlass(), k_HourGlassChar);

            System.Console.WriteLine(hourGlassStr);
        }

        // Gets custom size of an hour-glass from user
        private static uint getCustomLengthOfHourGlass()
        {
            uint customLength;
            string customLengthStr = string.Empty;
            bool isValidInput;

            System.Console.WriteLine("Please insert the size of the hour glass:");
            do
            {
                customLengthStr = System.Console.ReadLine();
                isValidInput = uint.TryParse(customLengthStr, out customLength);
                if (!isValidInput)
                {
                    System.Console.WriteLine("Invalid input! Please try again:");
                }
            }
            while (!isValidInput);

            return customLength;
        }
    }
}
