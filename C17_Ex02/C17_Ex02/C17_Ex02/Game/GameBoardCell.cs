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

        private eType m_Type;

        public eType Type
        {
            get
            {
                return m_Type;
            }
        }

        public GameBoardCell(eType i_Type)
        {
            m_Type = i_Type;
        }
    }
}
