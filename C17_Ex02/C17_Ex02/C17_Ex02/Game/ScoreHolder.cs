using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C17_Ex02.Game
{
    class ScoreHolder
    {
        private readonly int r_NumOfPlayers;
        private List<int> m_ScoreList;

        public ScoreHolder(int i_NumOfPlayers)
        {
            r_NumOfPlayers = i_NumOfPlayers;
            m_ScoreList = new List<int>(r_NumOfPlayers);
        }

        public void UpdateScore(GameResult i_GameResult)
        {
            if(i_GameResult.Result == GameResult.eResult.Draw)
            {
                m_ScoreList.ForEach(score => score++);
            }
            else
            {
                m_ScoreList[(int)i_GameResult.WinPlayerIndex] += 1; ;
            }
        }

        public List<int> GetScores()
        {
            return m_ScoreList;
        }
    }
}
