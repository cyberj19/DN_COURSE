using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C17_Ex02.BasicDataTypes;

namespace C17_Ex02.Game.Player
{
    class GamePlayer
    {
        public enum eType
        {
            HumanPlayer,
            ComputerPlayer
        }

        private readonly eType m_Type;
        private readonly GameBoardCell.eType m_CellType;

        public eType Type
        {
            get
            {
                return m_Type;
            }
        }

        public GameBoardCell.eType CellType
        {
            get
            {
                return m_CellType;
            }
        }

        public GamePlayer(eType i_Type, GameBoardCell.eType i_CellType)
        {
            m_Type = i_Type;
            m_CellType = i_CellType;
        }

        public bool IsInputRequiredForMove()
        {
            bool isInputRequired;

            switch (m_Type)
            {
                case eType.HumanPlayer:
                    isInputRequired = true;
                    break;
                case eType.ComputerPlayer:
                    isInputRequired = false;
                    break;
                default:
                    isInputRequired = false;
                    break;
            }

            return isInputRequired;
        }

        public GameBoardCell GenereateCell()
        {
            return new GameBoardCell(m_CellType);
        }

        public Point? MakeMove(Board<GameBoardCell> i_Board, GameLogic i_GameLogic, Point? i_Input)
        {
            Point? retMove;

            if (IsInputRequiredForMove() && (!i_Input.HasValue))
            {
                retMove = null;
            }
            else
            {
                switch (m_Type)
                {
                    case eType.ComputerPlayer:
                        retMove = ComputerLogic.MakeMove(i_Board, m_CellType, i_GameLogic); //todo: Consider instead of doing this static, make instace so it holds last move each time. less iterations needed
                        break; //todo: Need spacing after each break?
                    case eType.HumanPlayer:
                        retMove = HumanLogic.MakeMove(i_Board, (Point)i_Input, m_CellType, i_GameLogic);
                        break;
                    default:
                        retMove = null;
                        break;
                }
            }

            return retMove;
        }

    }
}
