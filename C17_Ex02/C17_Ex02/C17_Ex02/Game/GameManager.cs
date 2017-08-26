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

        private const int k_DrawWinnerValue = -1;
        private readonly GamePlayer[] m_Players;
        private readonly Board<GameBoardCell> m_Board;
        private readonly GameLogic m_Logic;
        private uint m_CurrPlayersTurn = 0;
        private int? m_Winner = null;

        //todo: Rethink if should allow anything from the outside to access the board this way! encapsulation, perhaps duplicate it
        public Board<GameBoardCell> Board
        {
            get
            {
                return m_Board;
            }
        }

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

        // handle a make move request from the game runner
        public eMoveResult MakeGameMove(Point? i_InputForMove)
        {
            eMoveResult retResult;

            if (IsGameOver())
            {
                retResult = eMoveResult.UnknownFailure;
            }
            else 
            {
                retResult = handleValidMakeMoveRequest(i_InputForMove);
            }

            return retResult;
        }

        // Handle a valid move request
        private eMoveResult handleValidMakeMoveRequest(Point? i_InputForMove)
        {
            eMoveResult retResult;

            Point? currMove = m_Players[m_CurrPlayersTurn].MakeMove(m_Board, m_Logic, i_InputForMove);
            if (!currMove.HasValue)
            {
                retResult = eMoveResult.BadInput;
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

        // Perform a move by one of the players
        private eMoveResult performMove(Point i_Move)
        {
            eMoveResult retResult;
            GameResult? gameResult = null;

            m_Board.Set(i_Move, m_Players[m_CurrPlayersTurn].GenereateCell());
            gameResult = m_Logic.GetGameResultIfGameOver();

            if (gameResult.HasValue)
            {
                retResult = eMoveResult.GameOver;
                if (gameResult.Value.Result == GameResult.eResult.Draw)
                {
                    m_Winner = k_DrawWinnerValue;
                }
                else
                {
                    m_Winner = (int)gameResult.Value.WinPlayerIndex; //todo: currently looser

                }
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
