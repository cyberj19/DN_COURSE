using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C17_Ex02.Generators;
namespace C17_Ex02.BasicDataTypes
{
    class Board<T>
    {
        private const int k_FirstItemInRowIndex = 0;
        private const int k_OneItemRight = 1;
        private const int k_OneItemRightAfterEachRowIteration = 1;
        private const int k_OneItemLeft = -1;
        private const int k_OneItemLeftAfterEachRowIteration = -1;
        private T[,] m_Cells;
        private readonly uint m_NumRows;
        private readonly uint m_NumCols;
        
        public uint Rows
        {
            get
            {
                return m_NumRows;
            }
        }

        public uint Cols
        {
            get
            {
                return m_NumCols;
            }
        }

        public Board(uint i_NumRows, uint i_NumCols)
        {
            //todo: Max Rows/Cols? atleast not empty. Right diago function needs last item..
            m_NumRows = i_NumRows;
            m_NumCols = i_NumCols;
            m_Cells = new T[i_NumRows, i_NumCols];
        }

        //todo: Consider changing to bool, but then we should check after each time instead of throwing an exception
        public void Set(Point i_Pos, T i_NewCell)
        {
            //todo: MAke sure Y and x at right pos
            m_Cells[i_Pos.Y, i_Pos.X] = i_NewCell;
        }

        public T Get(Point i_Pos)
        {
            return m_Cells[i_Pos.Y, i_Pos.X];
        }

        public TwoDimensionalArrayGenerator<T> GetItemsGenerator()
        {
            //todo: Same thing with x and y. if Y stays first there's no problem with the outer
            RangeGenerator outerGenerator = new RangeGenerator((int)m_NumRows);
            RangeGenerator innerGenerator = new RangeGenerator((int)m_NumCols);

            return new TwoDimensionalArrayGenerator<T>(outerGenerator, innerGenerator, m_Cells);
        }

        public TwoDimensionalArrayGenerator<T> GetRowGenerator(uint i_Row)
        {
            //todo: Check irow out of bounds or wait for exception to be thrown later?
            //todo: Same thing with x and y. if Y stays first there's no problem with the outer
            RangeGenerator outerGenerator = new RangeGenerator((int)i_Row, (int)i_Row + 1);
            RangeGenerator innerGenerator = new RangeGenerator((int)m_NumCols);

            return new TwoDimensionalArrayGenerator<T>(outerGenerator, innerGenerator, m_Cells);
        }

        public TwoDimensionalArrayGenerator<T> GetColGenerator(uint i_Column)
        {
            //todo: Check irow out of bounds or wait for exception to be thrown later?
            //todo: Same thing with x and y. if Y stays first there's no problem with the outer
            RangeGenerator outerGenerator = new RangeGenerator((int)m_NumRows);
            RangeGenerator innerGenerator = new RangeGenerator((int)i_Column, (int)i_Column + 1);

            return new TwoDimensionalArrayGenerator<T>(outerGenerator, innerGenerator, m_Cells);
        }

        public TwoDimensionalArrayGenerator<T> GetLeftDiagonalGenerator()
        {
            RangeGenerator outerGenerator = new RangeGenerator((int)m_NumRows);
            RangeGenerator innerGenerator = new RangeGenerator(
                k_FirstItemInRowIndex,
                k_FirstItemInRowIndex + k_OneItemRight,
                k_OneItemRight,
                k_OneItemRightAfterEachRowIteration,
                k_OneItemRightAfterEachRowIteration);

            return new TwoDimensionalArrayGenerator<T>(outerGenerator, innerGenerator, m_Cells);
        }

        public TwoDimensionalArrayGenerator<T> GetRightDiagonalGenerator()
        {
            int lastItemInRowIndex = (int)m_NumCols;
            RangeGenerator outerGenerator = new RangeGenerator((int)m_NumRows);
            RangeGenerator innerGenerator = new RangeGenerator(
                lastItemInRowIndex,
                lastItemInRowIndex + k_OneItemLeft,
                k_OneItemLeft,
                k_OneItemLeftAfterEachRowIteration,
                k_OneItemLeftAfterEachRowIteration);

            return new TwoDimensionalArrayGenerator<T>(outerGenerator, innerGenerator, m_Cells);
        }

    }
}
//todo: add style cop conf to main sln consider deleting proj conf