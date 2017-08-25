using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C17_Ex02.BasicDataTypes;
using C17_Ex02.Game;
using C17_Ex02.Utils;
using C17_Ex02.Generators;


namespace C17_Ex02.UI
{
    class ConsoleUI
    {
        public static void DrawBoard(Board<GameBoardCell> i_Board)
        {
            byte counter = 1;

            RangeGenerator range = new RangeGenerator(2, (int)i_Board.Cols+1);
            while (!range.HasFinished()){
                Console.Write(range.Next().ToString() + ConsoleUtils.k_SpaceChar + ConsoleUtils.k_SpaceChar);
            }
            


            //run over the board
            TwoDimensionalArrayGenerator<GameBoardCell> generator = i_Board.GetItemsGenerator();

            while (!generator.HasFinished())
            {
                if (generator.IsOuterIterChangedSinceLastCheck())
                {
                    Console.WriteLine();
                    //this is a new line...
                    Console.Write(counter.ToString() + ConsoleUtils.k_SpaceChar + ConsoleUtils.k_ColumnsDelimiter + ConsoleUtils.k_SpaceChar);
                    counter++;
                }

                GameBoardCell currCell = generator.Next();
                //do something with current cell..
                Console.Write(currCell.ToString() + ConsoleUtils.k_ColumnsDelimiter);
            }
        }

    }
}
