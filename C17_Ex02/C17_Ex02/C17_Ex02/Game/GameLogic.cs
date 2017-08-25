using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C17_Ex02.BasicDataTypes;
using C17_Ex02.Game.Player;

namespace C17_Ex02.Game
{
    class GameLogic
    {
        private readonly Board<GameBoardCell> m_Board;
        private readonly GamePlayer[] m_Players;

        public GameLogic(Board<GameBoardCell> i_Board, GamePlayer[] i_Players)
        {
            m_Board = i_Board;
            m_Players = i_Players;
        }

        public bool IsEmptyCell(Point i_Move)
        {
            return m_Board.Get(i_Move).Type == GameBoardCell.eType.None;
        }

        public bool IsMoveValid(Point i_Move)
        {
            return m_Board.IsInBounds(i_Move) && IsEmptyCell(i_Move);
        }

        public uint? GetVictorious()
        {
            //todo:
            return null;
        }
    }
}
