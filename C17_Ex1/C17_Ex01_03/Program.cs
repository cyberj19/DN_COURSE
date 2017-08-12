using System;
using SimpleHourGlass = C17_Ex01_02.Program; //todo: Delete all using. he didnt teach this and he wants our program free of these lines as stated.
//todo: Instead using C17_Ex01_02.Program.Something when calling the class

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
            //todo: Missing space lines between next 2 lines
            string hourGlassStr = SimpleHourGlass.GenerateHourGlassStr(getCustomLengthOfHourGlass(), k_HourGlassChar);
            System.Console.WriteLine(hourGlassStr);
        }

        // Gets custom size of an hour-glass from user
        private static uint getCustomLengthOfHourGlass()
        {
            //todo: Cant declare & Use write line at the same time. take the writeline out of here and write it after the declerating.
            //todo: 2# also as stated in 4, Should use ReadLine only once. Not Twice. See proj 4
            uint customLength;
            System.Console.WriteLine("Please insert the size of the hour glass:");
            string customLengthStr = System.Console.ReadLine();

            while(!uint.TryParse(customLengthStr, out customLength))
            {
                System.Console.WriteLine("Invalid Input!{0}Please insert the size of the hour glass:", System.Environment.NewLine);
                customLengthStr = System.Console.ReadLine();
            }

            return customLength;
        }
    }
}
