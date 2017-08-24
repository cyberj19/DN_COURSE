using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C17_Ex02.Generators
{
    class RangeGenerator
    {
        private readonly int m_AdditionAfterEachIteration = 1;
        private readonly int m_StartAdditionAfterEachReset = 0;
        private readonly int m_EndAdditionAfterEachReset = 0;
        // these might change thus not read only
        private int m_StartIndex = 0;
        private int m_EndIndex = 0;
        private int m_CurrIndex = 0;

        public RangeGenerator(int i_StartIndex, int i_EndIndex, int i_AdditionAfterEachIteration, int i_StartAdditionAfterEachReset, int i_EndAdditionAfterEachReset)
        {
            m_StartIndex = i_StartIndex;
            m_EndIndex = i_EndIndex;
            m_AdditionAfterEachIteration = i_AdditionAfterEachIteration;
            m_StartAdditionAfterEachReset = i_StartAdditionAfterEachReset;
            m_EndAdditionAfterEachReset = i_EndAdditionAfterEachReset;
        }

        public RangeGenerator(int i_StartIndex, int i_EndIndex, int i_AdditionAfterEachIteration)
        {
            m_StartIndex = i_StartIndex;
            m_EndIndex = i_EndIndex;
            m_AdditionAfterEachIteration = i_AdditionAfterEachIteration;
        }

        public RangeGenerator(int i_StartIndex, int i_EndIndex)
        {
            m_StartIndex = i_StartIndex;
            m_EndIndex = i_EndIndex;
        }

        public RangeGenerator(int i_EndIndex)
        {
            m_EndIndex = i_EndIndex;
        }

        //todo: IS syntax ok? Nullabe can be used this way?
        public Nullable<int> Next()
        {
            Nullable<int> ret = null;

            if (!HasFinished())
            {
                ret = m_CurrIndex;
                m_CurrIndex += m_AdditionAfterEachIteration;
            }

            return ret;
        }

        public bool HasFinished()
        {
            bool isAscending = IsAscendingIteration();

            return (isAscending && (m_CurrIndex >= m_EndIndex)) || (!isAscending && (m_CurrIndex <= m_EndIndex));
        }

        public void Reset()
        {
            m_StartIndex += m_StartAdditionAfterEachReset;
            m_EndIndex += m_EndAdditionAfterEachReset;
            m_CurrIndex = m_StartIndex;
        }

        public bool IsAscendingIteration()
        {
            return m_AdditionAfterEachIteration > 0;
        }
    }
}
