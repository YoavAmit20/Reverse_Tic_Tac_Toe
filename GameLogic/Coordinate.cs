

namespace GameLogic
{
    public class Coordinate
    {
        private readonly int r_Row;
        private readonly int r_Column;

        public Coordinate(int i_Row, int i_Column)
        {
            this.r_Row = i_Row;
            this.r_Column = i_Column;
        }

        public int Row
        {
            get
            {
                return r_Row;
            }
        }
        public int Column
        {
            get
            {
                return r_Column;
            }
        }

        public bool IsCoordianteOnMainDiagonal()
        {
            return this.Column == this.Row;
        }

        public bool IsCoordianteOnSecondaryDiagonal(GameBoard i_Board)
        {
            return i_Board.GetBoardSize() - this.Column == this.Row;
        }

        public static bool TryParse(string i_Input, out Coordinate o_Result)
        {
            o_Result = null;
            string[] parts = i_Input.Split(',');
            bool isValid = parts.Length == 2;

            if (isValid && int.TryParse(parts[0], out int row) && int.TryParse(parts[1], out int column) && isValid)
            {
                o_Result = new Coordinate(row, column);
                isValid = true;
            }

            else
            {
                isValid = false;
            }

            return isValid;
        }
    }
}

