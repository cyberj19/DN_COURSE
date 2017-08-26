using System;
using C17_Ex02.BasicDataTypes;
using C17_Ex02.Game;
using C17_Ex02.Utils;
using C17_Ex02.Generators;

namespace C17_Ex02.UI
{
    class ConsoleUI
    {

        const byte k_NumberOfSignsPerColumn = 4;




        public static void DrawBoard(Board<GameBoardCell> i_Board)
        {
            byte counter = 1;
            System.Threading.Thread.Sleep(1000);
            Ex02.ConsoleUtils.Screen.Clear();
            Console.Write(ConsoleUtils.k_SpaceChar.ToString());
            RangeGenerator range = new RangeGenerator(1, (int)i_Board.Cols + 1);
            while (!range.HasFinished())
            {
                Console.Write(ConsoleUtils.k_SpaceChar + range.Next().ToString() + ConsoleUtils.k_SpaceChar + ConsoleUtils.k_SpaceChar);
            }

            Console.WriteLine();

            // Run over the board
            TwoDimensionalArrayGenerator<GameBoardCell> generator = i_Board.GetItemsGenerator();
            generator.IsOuterIterChangedSinceLastCheck();
            ConsoleUtils.PrintNumericMargins("{0}" + ConsoleUtils.k_ColumnsDelimiter, counter++);
            while (!generator.HasFinished())
            {              
                GameBoardCell currCell = generator.Next();
                Console.Write(ConsoleUtils.k_SpaceChar + currCell.ToString() + ConsoleUtils.k_SpaceChar + ConsoleUtils.k_ColumnsDelimiter); 

                if (generator.IsOuterIterChangedSinceLastCheck())   
                {
                    // print border
                    ConsoleUtils.PrintBorder(ConsoleUtils.k_BorderUnitSign, i_Board.Cols * k_NumberOfSignsPerColumn, ConsoleUtils.k_SpaceChar.ToString() + ConsoleUtils.k_BorderUnitSign.ToString());

                    if (!generator.HasFinished())
                    {
                        ConsoleUtils.PrintNumericMargins("{0}" + ConsoleUtils.k_ColumnsDelimiter, counter++);
                    }
                }     
            }
        }
    }
}
