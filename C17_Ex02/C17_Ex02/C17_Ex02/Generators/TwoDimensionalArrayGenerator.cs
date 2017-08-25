using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C17_Ex02.Generators
{
    class TwoDimensionalArrayGenerator<T>
    {
        //todo: consider a better name than inner and outer
        private RangeGenerator m_InnerRangeGenerator;
        private RangeGenerator m_OuterRangeGenerator;
        private T[,] m_ArrayObject;
        private int? m_CurrInnerIterator = null;
        private int? m_CurrOuterIterator = null;
        private bool m_IsOuterIterChangedSinceLastCheck = true;

        public int? OuterIterator
        {
            get
            {
                return m_CurrOuterIterator;
            }
        }

        public int? InnerIterator
        {
            get
            {
                return m_CurrInnerIterator;
            }
        }


        public TwoDimensionalArrayGenerator(RangeGenerator i_OuterRangeGenerator, RangeGenerator i_InnerRangeGenerator, T[,] i_ArrayObject)
        {
            m_InnerRangeGenerator = i_InnerRangeGenerator;
            m_OuterRangeGenerator = i_OuterRangeGenerator;
            m_ArrayObject = i_ArrayObject;

            if (!HasFinished())
            {
                m_CurrOuterIterator = m_OuterRangeGenerator.Next();
                m_CurrInnerIterator = m_InnerRangeGenerator.Next();
            }
        }

        public T Next()
        {
            T ret = default(T);

            if (!((m_CurrOuterIterator == null) || (m_CurrOuterIterator == null)))
            {
                //todo: make sure right order in brackets
                ret = m_ArrayObject[(int)m_CurrOuterIterator, (int)m_CurrInnerIterator];
                if (m_InnerRangeGenerator.HasFinished())
                {
                    m_InnerRangeGenerator.Reset();
                    m_CurrOuterIterator = m_OuterRangeGenerator.Next();
                    m_IsOuterIterChangedSinceLastCheck = true;
                }

                m_CurrInnerIterator = m_InnerRangeGenerator.Next();
            }

            return ret;
        }

        public bool HasFinished()
        {
            return m_OuterRangeGenerator.HasFinished() && m_InnerRangeGenerator.HasFinished();
        }

        public bool IsOuterIterChangedSinceLastCheck()
        {
            bool isOuterChangedOriginal = m_IsOuterIterChangedSinceLastCheck;

            m_IsOuterIterChangedSinceLastCheck = false;

            return isOuterChangedOriginal;
        }

        public void Reset()
        {
            m_InnerRangeGenerator.Reset();
            m_OuterRangeGenerator.Reset();
            m_IsOuterIterChangedSinceLastCheck = true;
        }
    }
}
