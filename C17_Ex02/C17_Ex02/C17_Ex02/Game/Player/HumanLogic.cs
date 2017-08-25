using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C17_Ex02.BasicDataTypes;

    //todo: Go over all using, make sure in all files doing new line after it
namespace C17_Ex02.Game.Player
{
    class HumanLogic
    {
        static public Point? MakeMove(Board<GameBoardCell> i_Board, Point i_Input, GameBoardCell.eType i_CellType, GameLogic i_GameLogic)
        {
            Point? retMove = null;

            // checking if move is valid both here and in "GameManager". If the move is not valid in this stage, its the user's input fault.
            // If the move is not valid in "GameManager" Then its an error!
            if (i_GameLogic.IsMoveValid(i_Input))
            {
                retMove = i_Input;
            }

            return retMove;
        }
    }
}
