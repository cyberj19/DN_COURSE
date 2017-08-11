using System;
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
            uint o_customLength;
            System.Console.WriteLine("Please insert the size of the hour glass:");
            string customLengthStr = System.Console.ReadLine();

            while(!uint.TryParse(customLengthStr, out o_customLength))
            {
                System.Console.WriteLine("Invalid Input!{0}Please insert the size of the hour glass:", System.Environment.NewLine);
                customLengthStr = System.Console.ReadLine();
            }

            return o_customLength;
        }
    }
}
