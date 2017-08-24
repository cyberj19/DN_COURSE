using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02.Game
{
    class GameBoard : Board<GameBoardCell>
    {
        //todo: Has someone won function.
        //todo: 3 other functions, is all rows same, is all cols same, is all 
        //board is generic. it can be used in 12512512 games. in our specific game we are using GameBoardCell. This GameBoard class will add more functionality
        //to the Board class that is not required by all the 124124 games
        //i had a good design idea but it might be a bit complicated so i need to rethink about it for a second.
        //todo: There's an overhead for calling it 12351251 times + it needs a state,k i got it but there's still an overhead for it. not sure if that matters
        //todo: The code will look better but there is still an overhead..
        // what about the other 12388388 games? (12512512 -124124)
    }
}