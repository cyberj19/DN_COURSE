using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C17_Ex02.BasicDataTypes;

namespace C17_Ex02.Generators
{
    //todo: split this class into 2 classes, one is a simple 2d range
    class TwoDimensionalArrayGenerator<T>
    {
        //todo: consider a better name than inner and outer
        private RangeGenerator m_InnerRangeGenerator;
        private RangeGenerator m_OuterRangeGenerator;
        private T[,] m_ArrayObject;
        private int? m_CurrInnerIterator = null;
        private int? m_CurrOuterIterator = null;
        private bool m_IsOuterIterChangedSinceLastCheck = true;
        private Point? m_LastNextCallPos = null;

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

        public Point? LastNextCallPos
        {
            get
            {
                return m_LastNextCallPos;
            }
        }

        public TwoDimensionalArrayGenerator(RangeGenerator i_OuterRangeGenerator, RangeGenerator i_InnerRangeGenerator, T[,] i_ArrayObject)
        {
            m_InnerRangeGenerator = i_InnerRangeGenerator;
            m_OuterRangeGenerator = i_OuterRangeGenerator;
            m_ArrayObject = i_ArrayObject;

            initIterators();
        }

        public T Next()
        {
            T ret = default(T);
            Point? currPosition = null;

            if (!HasFinished())
            {
                //todo: make sure right order in brackets
                ret = m_ArrayObject[(int)m_CurrOuterIterator, (int)m_CurrInnerIterator];
                currPosition = new Point((uint)m_CurrInnerIterator, (uint)m_CurrOuterIterator); //todo: Need to make sure no signed ranges in arrays.. or crash
                if (m_InnerRangeGenerator.HasFinished())
                {
                    m_InnerRangeGenerator.Reset();
                    m_CurrOuterIterator = m_OuterRangeGenerator.Next(); //todo: If finishedm will contain null. Doc about it or change to be clearer
                    m_IsOuterIterChangedSinceLastCheck = true;
                }

                m_CurrInnerIterator = m_InnerRangeGenerator.Next();
            }

            if (currPosition.HasValue)
            {
                m_LastNextCallPos = (Point)currPosition;
            }

            return ret;
        }
        //todo: returns that finished one step before finished?
        public bool HasIteratorsFinished()
        {
            return m_OuterRangeGenerator.HasFinished() && m_InnerRangeGenerator.HasFinished();
        }

        //todo: this is the new one, according to current values?  make sure it solves the problem
        public bool HasFinished()
        {
            return (!m_CurrOuterIterator.HasValue) || (!m_CurrInnerIterator.HasValue);
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
            initIterators();
        }

        private void initIterators()
        {
            if (!HasIteratorsFinished())
            {
                m_IsOuterIterChangedSinceLastCheck = true;
                m_CurrOuterIterator = m_OuterRangeGenerator.Next();
                m_CurrInnerIterator = m_InnerRangeGenerator.Next();
            }
        }
    }
}
