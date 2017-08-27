using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C17_Ex02.Game.Player;
using C17_Ex02.BasicDataTypes;
using C17_Ex02.Game;
using C17_Ex02.Utils;

namespace C17_Ex02.UI
{
    class ReversedTicTacToeParams
    {

        const uint k_BoardMinimalSize = 3;
        const uint k_BoardMaximalSize = 9;
        //todo: pass to C'tor what is playaer 1 what is player 2, board size etc'

        public static eGameType GetGameType()
        {
            return (eGameType)ConsoleUtils.GetPositiveNumberFromUser(
                String.Format(
                    "Please Choose Game Type:{0}{1}. Player vs. Player{0}{2}. Player vs. Computer",
                    System.Environment.NewLine,
                    eGameType.PlayerVsPlayer,
                    eGameType.PlayerVsComputer),
                (uint)eGameType.PlayerVsPlayer,
                (uint)eGameType.PlayerVsComputer);

        }

        public static uint GetBoardSize()
        {
            return ConsoleUtils.GetPositiveNumberFromUser(
                String.Format(
                    "Please Insert Board Size: ({0}-{1})",
                    k_BoardMinimalSize,
                    k_BoardMaximalSize),
                k_BoardMinimalSize,
                k_BoardMaximalSize);
        }
    }
}
