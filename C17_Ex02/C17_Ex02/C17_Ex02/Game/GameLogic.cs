using C17_Ex02.BasicDataTypes;
using C17_Ex02.Game.Player;
using C17_Ex02.Generators;

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

        // Check if a board cell is empty
        public bool IsEmptyCell(Point i_Move)
        {
            return m_Board.Get(i_Move).Type == GameBoardCell.eType.None;
        }

        // Check if a move is valid
        public bool IsMoveValid(Point i_Move)
        {
            return m_Board.IsInBounds(i_Move) && IsEmptyCell(i_Move);
        }

        public GameResult? GetGameResultIfGameOver() //todo: change to int, if draw then -1
        {
            GameResult? retGameResult = null;

            //todo: //todo: 2#mybe save state so we wont need to iterate each time?
            GameBoardCell.eType? winnerCellType = null;

            for (uint checkNum = 0; checkNum < GameOverConditionsCheckOrder.NumberOfChecks; checkNum++)
            {
                switch ((GameOverConditionsCheckOrder.eOrder)checkNum)
                {
                    case GameOverConditionsCheckOrder.eOrder.LeftDiagonal:
                        winnerCellType = getAllSameType(m_Board.GetLeftDiagonalGenerator());
                        break;
                    case GameOverConditionsCheckOrder.eOrder.RightDiagonal:
                        winnerCellType = getAllSameType(m_Board.GetRightDiagonalGenerator());
                        break;
                    case GameOverConditionsCheckOrder.eOrder.Row:
                        winnerCellType = getAllSameTypeRows();
                        break;
                    case GameOverConditionsCheckOrder.eOrder.Col:
                        winnerCellType = getAllSameTypeCols();
                        break;
                    case GameOverConditionsCheckOrder.eOrder.All:
                        if (IsBoardFull())
                        {
                            retGameResult = new GameResult(GameResult.eResult.Draw);
                        }

                        break;
                    default:
                        break;
                }
            }

            if (winnerCellType.HasValue)
            {
                retGameResult = new GameResult(GameResult.eResult.PlayerWon, cellTypeToPlayerIndex((GameBoardCell.eType)winnerCellType));
            }

            return retGameResult;
        }


        private uint cellTypeToPlayerIndex(GameBoardCell.eType i_Type)
        {
            uint? retIndex = null; //todo: make sure it throws on casting if we dont find
            //todo: need to rethink if wee want to support only 2 players or more here.
            //todo: currently saying whos the loser but not whos the winner
            if (i_Type != GameBoardCell.eType.None)
            {
                for (uint i = 0; i < m_Players.Length; i++)
                {
                    if (i_Type == m_Players[i].CellType)
                    {
                        retIndex = i; //todo:..... if did not find will return draw. potential bug
                    }
                }
            }

            return (uint)retIndex;
        }

        public bool IsBoardFull()
        {
            // note: This cannot be implemented in the Board class itself because there might be games where "Set" is not used uniquely on Board.
            // So the next calculation wont tell us that the board is full.
            return (m_Board.Rows * m_Board.Cols) == m_Board.NumTimesSetCalled;
        }


        private GameBoardCell.eType? getAllSameTypeRows()
        {
            GameBoardCell.eType? ret = null;

            for (uint i = 0; i < m_Board.Rows; i++)
            {
                ret = getAllSameType(m_Board.GetRowGenerator(i));
                if (ret.HasValue)
                {
                    break;
                }
            }

            return ret;
        }


        private GameBoardCell.eType? getAllSameTypeCols()
        {
            GameBoardCell.eType? ret = null;

            for (uint i = 0; i < m_Board.Cols; i++)
            {
                ret = getAllSameType(m_Board.GetColGenerator(i));
                if (ret.HasValue)
                {
                    break;
                }
            }

            return ret;
        }

        private GameBoardCell.eType? getAllSameType(TwoDimensionalArrayGenerator<GameBoardCell> i_Generator)
        {
            GameBoardCell.eType? ret = null;
            GameBoardCell.eType lastType = i_Generator.Next().Type; //todo: Not supporting board of 1x1 perhaps should check for Null here
            bool checkStatus = true; //todo: refactor on this function, i dont like the loop

            while (!i_Generator.HasFinished())
            {
                GameBoardCell currCell = i_Generator.Next();

                if (currCell.Type == GameBoardCell.eType.None)
                {
                    checkStatus = false;
                    break;
                }

                if (currCell.Type != lastType)
                {
                    checkStatus = false;
                    break;
                }                
            }

            if (checkStatus)
            {
                ret = lastType;
            }

            return ret;
        }
    }
}
