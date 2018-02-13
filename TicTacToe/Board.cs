using System.Linq;

namespace TicTacToe
{
    public enum Check
    {
        Row,
        Column,
        Diagonal,
        ReverseDiagonal
    }

    public enum Figures
    {
        X,
        O,
        None
    }

    public sealed class Board
    {
        private Figures[][] _cells;

        public Board(int rowsNumber, int colsNumber, Figures[][] boardFigureses)
        {
            RowsNumber = rowsNumber;
            ColsNumber = colsNumber;

            InitBoard(null);

            if (boardFigureses != null)
            {
                PopulateBoard(boardFigureses);
            }
        }

        public int ColsNumber { get; private set; }
        public int RowsNumber { get; private set; }

        public int Length
        {
            get { return _cells.Length; }
        }

        public Figures[][] GetCells()
        {
            return (Figures[][]) _cells.Clone();
        }

        public void InitBoard(Figures[][] boardFigures)
        {
            //init cells
            _cells = new Figures[RowsNumber][];
            for (int i = 0; i < RowsNumber; i++)
            {
                _cells[i] = Enumerable.Repeat(Figures.None, ColsNumber).ToArray();
            }
        }

        private void PopulateBoard(Figures[][] boardFigures)
        {
            for (int i = 0; i < RowsNumber; i++)
            {
                for (int j = 0; j < ColsNumber; j++)
                {
                    _cells[i][j] = boardFigures[i][j];
                }
            }
        }

        public bool SetFigure(Move move)
        {
            if (move.X >= 0
                && move.X < RowsNumber
                && move.Y >= 0
                && move.Y < ColsNumber
                && _cells[move.X][move.Y] == Figures.None)
            {
                _cells[move.X][move.Y] = move.Figure;

                return true;
            }

            return false;
        }

        public bool IsEmpty(Move move)
        {
            if (move.X < 0 || move.X >= RowsNumber || move.Y < 0 || move.Y >= ColsNumber)
            {
                return false;
            }

            return _cells[move.X][move.Y] == Figures.None;
        }

        internal bool HasEmptyCells()
        {
            return _cells.SelectMany(x => x).Any(x => x == Figures.None);
        }

        public Figures GetFigure(int index, int dynamcIndex, Check check)
        {
            switch (check)
            {
                case Check.Row:
                    return _cells[index][dynamcIndex];
                    break;

                case Check.Column:
                    return _cells[dynamcIndex][index];
                    break;

                case Check.Diagonal:
                    return _cells[dynamcIndex][dynamcIndex];
                    break;

                case Check.ReverseDiagonal:
                    return _cells[Length - 1 - dynamcIndex][dynamcIndex];
                    break;

                default:
                    return Figures.None;
            }
        }
    }
}