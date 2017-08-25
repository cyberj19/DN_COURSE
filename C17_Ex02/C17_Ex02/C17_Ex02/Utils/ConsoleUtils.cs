﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C17_Ex02.Generators;

namespace C17_Ex02.Utils
{
    public class ConsoleUtils
    {
        public const char k_ColumnsDelimiter = '|';
        public const char k_SpaceChar = ' ';
        public const char k_BorderUnitSign = '=';


        public static void PrintBorder(char i_BorderUnitSign, uint i_NumberOfUnits, string i_MarginStr)
        {
            Console.WriteLine();
            PrintMargins(i_MarginStr);
            RangeGenerator range = new RangeGenerator((int)i_NumberOfUnits);
            while (!range.HasFinished())
            {
                Console.Write(i_BorderUnitSign);
                range.Next();
            }
            Console.WriteLine();
        }

        public static void PrintNumericMargins(string i_MarginStr, int i_RowNumber)
        {
            PrintMargins(String.Format(i_MarginStr, i_RowNumber));
        }

        public static void PrintMargins(string i_MarginStr)
        {
            Console.Write(i_MarginStr);
        }

    }
}
