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

        private GamePlayer[] m_Players;
        private uint m_CurrPlayersTurn = 0;
        private uint? m_Winner = null;
        private readonly Board<GameBoardCell> m_Board;
        private readonly GameLogic m_Logic;

        //todo: Should randomize who goes first?

        public GameManager(uint i_BoardSize, GamePlayer i_FirstPlayer, GamePlayer i_SecondPlayer)
        {
            m_Players = new GamePlayer[2] {i_FirstPlayer, i_SecondPlayer};
            m_Board = new Board<GameBoardCell>(i_BoardSize, i_BoardSize);
            m_Logic = new GameLogic(); //todo: Need to get board...
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
                Point? currMove = m_Players[m_CurrPlayersTurn].MakeMove(m_Board, m_Logic, i_InputForMove);
                if (!currMove.HasValue)
                {
                    retResult = eMoveResult.BadInput; //todo: If computer returns null? 
                }
                else
                {
                    //todo: MAke this function look better not 5 if's
                    if (!m_Logic.IsMoveValid((Point)currMove))
                    {
                        retResult = eMoveResult.UnknownFailure;
                    }
                    else
                    {
                        //todo: Move to function
                        GameBoardCell newCell = new GameBoardCell(m_Players[m_CurrPlayersTurn].CellType);
                        m_Board.Set((Point)currMove, newCell);

                        uint? victoriousPlayer = m_Logic.GetVictorious();

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
                    }
                }
            }

            return retResult;
        }
    }
}
