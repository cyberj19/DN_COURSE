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

            while(!uint.TryParse(customLengthStr, out customLength)) //todo: Perhaps add "....".Length == 0, so we wont run TryParse at the first time for no reason
            {
                System.Console.WriteLine("Please insert the size of the hour glass:"); //todo: Dont know man. Mybe should notify about errors? dont know if neccesary (i mean different str for first time and other times)
                customLengthStr = System.Console.ReadLine();
            }

            return customLength;
        }
    }
}
