using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C17_Ex02.BasicDataTypes;

namespace C17_Ex02.Game
{
    // todo: & note: Would inherit here. But it is not allowed, so intead will hold Board as a member
    class GameBoard
    {
        private Board<GameBoardCell> m_Board;
    }
}
