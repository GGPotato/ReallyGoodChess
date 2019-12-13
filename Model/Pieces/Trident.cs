using System;
using System.Collections.Generic;

namespace Model.Pieces
{
    public class Trident : BasePiece // Aka nobbly one down front
    {
        protected override char Char => '♆';

        private Vector FrontLeft => new Vector(Color == Color.White ? 1 : -1, -1);
        private Vector Front => new Vector(Color == Color.White ? 1 : -1,0);
        private Vector FrontRight => new Vector(Color == Color.White ? 1 : -1, 1);
      

        public override BasePiece[][,] GetMoves(BasePiece[,] board)
        {
            var boards = new List<BasePiece[,]>();
            var moveOrTakes = new[] { Location + Front, Location + FrontLeft, Location + FrontRight };
            
            foreach( var moveOrTake in moveOrTakes)
            {
                if (IsOnBoard(moveOrTake)
                    && (board[moveOrTake.X, moveOrTake.Y] == null
                    || board[moveOrTake.X, moveOrTake.Y].Color != Color))
                {
                    if (!IsOnBoard(moveOrTake+Front))
                    {
                        boards.Add(CloneBoardAndMove<Knight>(board, moveOrTake));
                        boards.Add(CloneBoardAndMove<Rook>(board, moveOrTake));
                        boards.Add(CloneBoardAndMove<King>(board, moveOrTake));
                        boards.Add(CloneBoardAndMove<Bishop>(board, moveOrTake));
                    }
                    else
                    {
                        boards.Add(CloneBoardAndMove<Trident>(board, moveOrTake));
                    }
                }
              

                var justTake = moveOrTake + Front;
                if (IsOnBoard(justTake)
                   && board[justTake.X, justTake.Y] != null
                   && board[justTake.X, justTake.Y].Color != Color)
                {
                    if (!IsOnBoard(justTake + Front))
                    {
                        boards.Add(CloneBoardAndMove<Knight>(board, justTake));
                        boards.Add(CloneBoardAndMove<Rook>(board, justTake));
                        boards.Add(CloneBoardAndMove<King>(board, justTake));
                        boards.Add(CloneBoardAndMove<Bishop>(board, justTake));
                    }
                    else
                    {
                        boards.Add(CloneBoardAndMove<Trident>(board, justTake));
                    }
                    
                }
            }

            return boards.ToArray();
        }
    }
}
