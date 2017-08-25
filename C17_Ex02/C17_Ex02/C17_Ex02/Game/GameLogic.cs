using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool IsEmptyCell(Point i_Move)
        {
            return m_Board.Get(i_Move).Type == GameBoardCell.eType.None;
        }

        public bool IsMoveValid(Point i_Move)
        {
            return m_Board.IsInBounds(i_Move) && IsEmptyCell(i_Move);
        }



        public int? GetVictorious() //todo: change to int, if draw then -1
        {
            int? ret = null;
            //todo: //todo: 2#mybe save state so we wont need to iterate each time?
            GameBoardCell.eType? winner = null;

            for (uint checkNum = 0; checkNum < GameOverConditionsCheckOrder.NumberOfChecks; checkNum++)
            {
                switch ((GameOverConditionsCheckOrder.eOrder)checkNum)
                {
                    case GameOverConditionsCheckOrder.eOrder.LeftDiagonal:
                        winner = getAllSameType(m_Board.GetLeftDiagonalGenerator());
                        break;
                    case GameOverConditionsCheckOrder.eOrder.RightDiagonal:
                        winner = getAllSameType(m_Board.GetRightDiagonalGenerator());
                        break;
                    case GameOverConditionsCheckOrder.eOrder.Row:
                        winner = getAllSameTypeRows();
                        break;
                    case GameOverConditionsCheckOrder.eOrder.Col:
                        winner = getAllSameTypeCols();
                        break;
                    case GameOverConditionsCheckOrder.eOrder.All:
                        winner = getAllSameTypeAll(); //todo: bad name
                        break;
                    default:
                        break;
                }
            }

            //todo: Perhaps instead of going over last function get items generator check on the other functions if there was a none type!

            if (winner.HasValue)
            {
                ret = typeToPlayerIndex((GameBoardCell.eType)winner);
            }

            return ret;
        }


        private int typeToPlayerIndex(GameBoardCell.eType i_Type)
        {
            int retIndex = -1;

            if (i_Type != GameBoardCell.eType.None)
            {
                for (int i = 0; i < m_Players.Length; i++)
                {
                    if (i_Type == m_Players[i].CellType)
                    {
                        retIndex = i; //todo:..... if did not find will return draw. potential bug
                    }
                }
            }

            return retIndex;
        }

        private GameBoardCell.eType? getAllSameTypeAll()
        {
            TwoDimensionalArrayGenerator<GameBoardCell> generator = m_Board.GetItemsGenerator();
            GameBoardCell.eType? ret = null;
            bool checkStatus = true; //todo: refactor on this function, i dont like the loop

            while (!generator.HasFinished())
            {
                GameBoardCell currCell = generator.Next();

                if (currCell.Type != GameBoardCell.eType.None)
                {
                    checkStatus = false;
                    break;
                }
            }

            if (checkStatus)
            {
                ret = GameBoardCell.eType.None;
            }

            return ret;
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
