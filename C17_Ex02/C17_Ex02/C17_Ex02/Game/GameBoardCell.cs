using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C17_Ex02.Game
{
    struct GameBoardCell
    {
        public enum eType
        {
            None,
            X,
            O
        }

        private const string k_StringO = "O";
        private const string k_StringX = "X";
        private const string k_StringNone = " ";
        private readonly eType m_Type;
        
        public eType Type
        {
            get
            {
                return m_Type;
            }
        }
        /* todo
        public static GameBoardCell X
        {
            get
            {
                return new GameBoardCell(eType.X);
            }
        }

        public static GameBoardCell O
        {
            get
            {
                return new GameBoardCell(eType.O);
            }
        }

        public static GameBoardCell None
        {
            get
            {
                return new GameBoardCell(eType.None);
            }
        }
        */

        public GameBoardCell(eType i_Type)
        {
            m_Type = i_Type;
        }

        public override string ToString()
        {
            string ret;

            switch(m_Type)
            {
                case eType.O:
                    ret = k_StringO;
                    break;
                case eType.X:
                    ret = k_StringX;
                    break;
                case eType.None:
                default:
                    ret = k_StringNone;
                    break;
            }

            return ret;
        }
    }
}
