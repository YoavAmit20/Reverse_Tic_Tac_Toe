
namespace GameLogic
{
    public class GameBoard
    {        
        private readonly ePlayerSymbols[,] r_Board;

        public ePlayerSymbols[,] Board 
        { 
            get 
            { 
                return r_Board; 
            }
        }

        public GameBoard(int i_Size)
        {
            this.r_Board = new ePlayerSymbols[i_Size + 1, i_Size + 1];
        }

        public void SetCell(Coordinate i_Coordinate, Player i_CurrentPlayer)
        {
            this.r_Board[i_Coordinate.Row, i_Coordinate.Column] = i_CurrentPlayer.PlayerSymbol;
        }

        public ePlayerSymbols GetCellSymbol(Coordinate i_Coordinate)
        {
            return Board[i_Coordinate.Row, i_Coordinate.Column];
        }
        
        public int GetBoardSize()
        {
            return r_Board.GetLength(0);
        }

        public bool IsEmptyCell(Coordinate i_Coordiante) 
        {
            return this.r_Board[i_Coordiante.Row, i_Coordiante.Column] == ePlayerSymbols.None;
        }

        public bool IsBoardFull()
        {
            bool isFull = true;

            for (int i = 1;  i < Board.GetLength(0) && isFull; i++)
            {
                for (int j = 1; j < Board.GetLength(1) && isFull; j++)
                {
                    isFull = Board[i, j] != ePlayerSymbols.None;
                }

            }

            return isFull;
        }

        public bool IsStreak(Coordinate i_PlayersCoordinate)
        {
            bool isStreak = false;

            if (i_PlayersCoordinate.IsCoordianteOnMainDiagonal())
            {
                isStreak = isMainDiagonalStreak(i_PlayersCoordinate);
            }

            if (!isStreak && i_PlayersCoordinate.IsCoordianteOnSecondaryDiagonal(this))
            {
                isStreak = isSecondaryDiagonalStreak(i_PlayersCoordinate);
            }

            if (!isStreak)
            {
                isStreak = isRowStreak(i_PlayersCoordinate);
            }

            if (!isStreak)
            {
                isStreak = isColumnStreak(i_PlayersCoordinate);
            }

            return isStreak;
        }
        private bool isMainDiagonalStreak(Coordinate i_PlayersCoordinate)
        {
            bool isDouEqual = false;
            int countElementsInStreak = 1;

            if (i_PlayersCoordinate.IsCoordianteOnMainDiagonal())
            {
                for (int i = 2; i < Board.GetLength(1); i++)
                {
                    isDouEqual = GetCellSymbol(new Coordinate(i, i)) != ePlayerSymbols.None;
                    isDouEqual = isDouEqual && Board[i - 1, i - 1] == Board[i, i];
                    if (isDouEqual)
                    {
                        countElementsInStreak++;
                    }

                }

            }

            return countElementsInStreak == Board.GetLength(1) - 1;
        }
        private bool isSecondaryDiagonalStreak(Coordinate i_PlayersCoordinate)
        {
            bool isDouEqual = false;
            int countElementsInStreak = 1;

            if (i_PlayersCoordinate.IsCoordianteOnSecondaryDiagonal(this))
            {
                for (int i = 2; i < Board.GetLength(1); i++)
                {
                    isDouEqual = GetCellSymbol(new Coordinate(i, Board.GetLength(1) - i)) != ePlayerSymbols.None;
                    isDouEqual = isDouEqual && Board[i - 1, Board.GetLength(1) - i + 1] == this.Board[i, Board.GetLength(1) - i];
                    if (isDouEqual)
                    {
                        countElementsInStreak++;
                    }

                }

            }

            return countElementsInStreak == Board.GetLength(1) - 1;
        }
        private bool isRowStreak(Coordinate i_PlayersCoordinate)
        {
            int countElementsInStreak = 1;
            bool isDouEqual = false;

            for (int i = 2; i < Board.GetLength(1); i++)
            {
                isDouEqual = GetCellSymbol(new Coordinate(i_PlayersCoordinate.Row, i)) != ePlayerSymbols.None;
                isDouEqual = Board[i_PlayersCoordinate.Row, i - 1] == Board[i_PlayersCoordinate.Row, i];
                if (isDouEqual)
                {
                    countElementsInStreak++;
                }

            }

            return countElementsInStreak == Board.GetLength(1) - 1;
        }
        private bool isColumnStreak(Coordinate i_PlayersCoordinate)
        {
            int countElementsInStreak = 1;
            bool isDouEqual = false;

            for (int i = 2; i < this.Board.GetLength(1); i++)
            {
                isDouEqual = this.GetCellSymbol(new Coordinate(i, i_PlayersCoordinate.Column)) != ePlayerSymbols.None;
                isDouEqual = this.Board[i - 1, i_PlayersCoordinate.Column] == Board[i, i_PlayersCoordinate.Column];
                if (isDouEqual)
                {
                    countElementsInStreak++;
                }

            }

            return countElementsInStreak == Board.GetLength(1) - 1;
        }
        public void Reset()
        {
            for (int i = 1; i < this.Board.GetLength(1); i++)
            {
                for (int j = 1; j < this.Board.GetLength(0); j++)
                {
                    Board[i, j] = ePlayerSymbols.None;
                }

            }

        }

        public bool IsCellPostionValid(Coordinate i_PlayersCoordinate)
        {
            const int k_MinimumCellPosition = 1;

            return i_PlayersCoordinate.Row < Board.GetLength(1) && i_PlayersCoordinate.Column < Board.GetLength(1) &&
                i_PlayersCoordinate.Row >= k_MinimumCellPosition && i_PlayersCoordinate.Column >= k_MinimumCellPosition && i_PlayersCoordinate != null;
        }

        public static bool IsValidSize(int i_Size)
        {
            const int k_minimumGameBoardSize = 4, k_maximumGameBoardSize = 10;

            return i_Size >= k_minimumGameBoardSize && i_Size <= k_maximumGameBoardSize;
        }
    }
}