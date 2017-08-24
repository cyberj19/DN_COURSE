using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02.BasicDataTypes
{
    class Board<T>
    {
        // todo: Better use BoardCell for polymorphism, but there's an impact on perforemance (According to last lesson <T> might be a better thing to use
        // tood: But, will be using Board on different projects (i.e UI) so we should be able to have common functions for all BoardCell types. Leaving this as it is atm
        private T[,] m_Cells;

        public uint Rows
        {
            get
            {
                // todo: Return number of rows
            }
        }

        public uint Cols
        {
            get
            {
                // todo: Return number of Cols
            }
        }


        public Board(uint i_NumRows, uint i_NumCols)
        {

        }

        public T GetCell(Point i_Pos)
        {
            // todo: Boundary check or let an exception be thrown
        }

        public bool SetCell(Point i_Pos, BoardCell i_Item)


        //todo: Implenet - ToString. I Agree with you on this one
        

        private bool BoundaryCheck(Point i_Pos)
        {

        }

        // todo: Helper functions for running over board (For example running a compare on a row/column/diag... or perhaps should recv an interface to a class
        // todo: That implements such a callback.  

            //todo: Bool, true to stop the iteration, false to continue.  or the other way around. anyways the bool controls it.
            //todo: But it should also be able to return a final value. 
            //todo: iteration type is a parameter to the handle single cell run iteration function so the function will know the reason it is being called
            //todo: (For example comparing in order to check if someone won the game, or if doing anything else) it would be an enum in the deriving class
        protected virtual bool HandleSingleCellRunIteration<T2>(ref T2 i_State, out bool o_RetValue) //todo: check that parameter with ref is i_
        {
            //todo: implement in deriving classes -listen
        }
        //todo: Note: This way it would be easier later on to implement a check if there is X on all rows/columns/diag etc'
        protected bool RunOnAllColumns<T2>(ref T2 i_State, uint i_Row)
        {
            //todo: Run over all columns and call HandleSingleCellRunIteration until  finishing or it return false.
        }


        protected bool RunOnAllColumns<T2>(ref T2 i_State)
        {
            //todo: Calls  RunOnAllColumns with i_Row, so it will be called .Rows number of times

        }

        protected bool RunOnAllRows(uint i_IterationType, out bool o_RetValue)
        {
            //todo: same as on columns, but on rows. calls the HandleSingle..
        }

        protected bool RunOnLeftDiag(uint i_IterationType, out bool o_RetValue)
        {

        }

        protected bool RunOnRightDiag(uint i_IterationType, out bool o_RetValue)
        {

        }
    }
    }
}
