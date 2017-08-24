using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C17_Ex02.Game.Player;

namespace C17_Ex02.Game
{
    class GameManager
    {
        enum eRoundResult
        {
            Success,
            BadInput,
            UnknownFailure
        }

        private bool m_IsInputRequiredForNextTurn;

        public GameManager(uint i_BoardSize, HumanPlayer i_HumanPlayer, ComputerPlayer i_SecondPlayer)
        {

        }

        public GameManager(uint i_BoardSize, HumanPlayer i_HumanPlayer, HumanPlayer i_SecondPlayer)
        {

        }
        //todo: Decide randomally who starts and who has x and who has o?

    }
}
