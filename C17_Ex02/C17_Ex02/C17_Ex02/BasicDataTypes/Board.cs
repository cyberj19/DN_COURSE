using C17_Ex02.Generators;

namespace C17_Ex02.BasicDataTypes
{
    // Represents a board with type 'T' Cells
    class Board<T>
    {
        private const int k_FirstItemInRowIndex = 0;
        private const int k_OneItemRight = 1;
        private const int k_OneItemRightAfterEachRowIteration = 1;
        private const int k_OneItemLeft = -1;
        private const int k_OneItemLeftAfterEachRowIteration = -1;
        private readonly T[,] m_Cells;
        private readonly uint m_NumRows;
        private readonly uint m_NumCols;
        private uint m_NumTimesSetCalled = 0;

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

        public uint NumTimesSetCalled
        {
            get
            {
                return m_NumTimesSetCalled;
            }
        }

        public Board(uint i_NumRows, uint i_NumCols)
        {
            m_NumRows = i_NumRows;
            m_NumCols = i_NumCols;
            m_Cells = new T[i_NumRows, i_NumCols];
        }

        // check if position is in bounds of the board
        public bool IsInBounds(Point i_Pos)
        {
            return (i_Pos.X < m_NumCols) && (i_Pos.Y < m_NumRows);
        }

        // Set cell of specific index
        public void Set(Point i_Pos, T i_NewCell)
        {
            m_Cells[i_Pos.Y, i_Pos.X] = i_NewCell;
            m_NumTimesSetCalled++;
        }

        // Get cell at specific index
        public T Get(Point i_Pos)
        {
            return m_Cells[i_Pos.Y, i_Pos.X];
        }

        // Get regular generator, access all items
        public TwoDimensionalArrayGenerator<T> GetItemsGenerator()
        {
            RangeGenerator outerGenerator = new RangeGenerator((int)m_NumRows);
            RangeGenerator innerGenerator = new RangeGenerator((int)m_NumCols);

            return new TwoDimensionalArrayGenerator<T>(outerGenerator, innerGenerator, m_Cells);
        }

        // Get row generator, access items in a specific row
        public TwoDimensionalArrayGenerator<T> GetRowGenerator(uint i_Row)
        {
            RangeGenerator outerGenerator = new RangeGenerator((int)i_Row, (int)i_Row + 1);
            RangeGenerator innerGenerator = new RangeGenerator((int)m_NumCols);

            return new TwoDimensionalArrayGenerator<T>(outerGenerator, innerGenerator, m_Cells);
        }

        // Get col generator, access items in a specific col
        public TwoDimensionalArrayGenerator<T> GetColGenerator(uint i_Column)
        {
            RangeGenerator outerGenerator = new RangeGenerator((int)m_NumRows);
            RangeGenerator innerGenerator = new RangeGenerator((int)i_Column, (int)i_Column + 1);

            return new TwoDimensionalArrayGenerator<T>(outerGenerator, innerGenerator, m_Cells);
        }

        // Get left diagonal generator, access items in the Left Diagonal (Starting from top-left)
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

        // Get right diagonal generator, access items in the Right Diagonal (Starting from top-Right)
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