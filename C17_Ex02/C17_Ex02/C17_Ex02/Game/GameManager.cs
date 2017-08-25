using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C17_Ex02.Game.Player;
using C17_Ex02.BasicDataTypes;

//todo: Doing game twice (Game.Gamesomething...)
namespace C17_Ex02.Game
{
    class GameManager
    {
        public enum eMoveResult
        {
            Success,
            GameOver,
            BadInput,
            UnknownFailure
        }

        private readonly GamePlayer[] m_Players;
        private readonly Board<GameBoardCell> m_Board;
        private readonly GameLogic m_Logic;
        private uint m_CurrPlayersTurn = 0;
        private uint? m_Winner = null;

        public GameManager(uint i_BoardSize, GamePlayer[] i_Players)
        {
            m_Players = i_Players;
            m_Board = new Board<GameBoardCell>(i_BoardSize, i_BoardSize);
            m_Logic = new GameLogic(m_Board, m_Players);
        }

        public bool IsInputRequiredForCurrentTurn()
        {
            return m_Players[m_CurrPlayersTurn].IsInputRequiredForMove();
        }

        public bool IsGameOver()
        {
            return m_Winner.HasValue;
        }

        public eMoveResult MakeGameMove(Point? i_InputForMove)
        {
            eMoveResult retResult;

            if (IsGameOver())
            {
                retResult = eMoveResult.UnknownFailure;
            }
            else 
            {
                retResult = handleMakeMoveRequest(i_InputForMove);
            }

            return retResult;
        }

        private eMoveResult handleMakeMoveRequest(Point? i_InputForMove)
        {
            eMoveResult retResult;

            Point? currMove = m_Players[m_CurrPlayersTurn].MakeMove(m_Board, m_Logic, i_InputForMove);
            if (!currMove.HasValue)
            {
                retResult = eMoveResult.BadInput; //todo: If computer returns null? 
            }
            else
            {
                if (!m_Logic.IsMoveValid((Point)currMove))
                {
                    retResult = eMoveResult.UnknownFailure;
                }
                else
                {
                    retResult = performMove((Point)currMove);
                }
            }

            return retResult;
        }

        private eMoveResult performMove(Point i_Move)
        {
            eMoveResult retResult;
            uint? victoriousPlayer;

            m_Board.Set(i_Move, m_Players[m_CurrPlayersTurn].GenereateCell());
            victoriousPlayer = m_Logic.GetVictorious();
            if (victoriousPlayer.HasValue)
            {
                m_Winner = victoriousPlayer;
                retResult = eMoveResult.GameOver;
            }
            else
            {
                retResult = eMoveResult.Success;
                m_CurrPlayersTurn++;
                if (m_CurrPlayersTurn >= m_Players.Length)
                {
                    m_CurrPlayersTurn = 0;
                }
            }

            return retResult;
        }
    }
}
