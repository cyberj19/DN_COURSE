using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C17_Ex02.Game
{
    class GameOverConditionsCheckOrder
    {

        public enum eOrder
        {
            LeftDiagonal = 0,
            RightDiagonal,
            Row,
            Col,
            All,
        }

        private const uint k_NumberOfChecks = 5;

        public static uint NumberOfChecks
        {
            get
            {
                return k_NumberOfChecks;
            }
        }

    }
}
