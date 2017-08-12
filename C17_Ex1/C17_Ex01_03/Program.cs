using SimpleHourGlass = C17_Ex01_02.Program; /*// todo: Delete all using. he didnt teach this and he wants our program free of these lines as stated.
// todo: Instead using C17_Ex01_02.Program.Something when calling the class*/

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

            while(!uint.TryParse(customLengthStr, out customLength))
            {
                System.Console.WriteLine("Please insert the size of the hour glass:");
                customLengthStr = System.Console.ReadLine();
            }

            return customLength;
        }
    }
}
