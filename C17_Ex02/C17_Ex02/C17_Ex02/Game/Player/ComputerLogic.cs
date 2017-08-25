using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C17_Ex02.BasicDataTypes;
using C17_Ex02.Generators;

namespace C17_Ex02.Game.Player
{
    class ComputerLogic
    {
        static public Point? MakeMove(Board<GameBoardCell> i_Board, GameBoardCell.eType i_CellType, GameLogic i_GameLogic)
        {
            Point? retMove = null;
            //todo: might have to check LastNextCallValue not null
            TwoDimensionalArrayGenerator<GameBoardCell> generator = i_Board.GetItemsGenerator();
            
            while (!generator.HasFinished())
            {
                GameBoardCell currentBoardCell = generator.Next();
                
                if (currentBoardCell.Type == GameBoardCell.eType.None)
                {
                    retMove = generator.LastNextCallPos;
                    break;
                }
            }

            return retMove;
        }
    }
}
