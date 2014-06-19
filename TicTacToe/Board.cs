using System;

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

    public class Board
    {
        public readonly int ColsNumber;
        public readonly int RowsNumber;

        private Figures[][] _cells;

        public Board(int rowsNumber, int colsNumber)
        {
            RowsNumber = rowsNumber;
            ColsNumber = colsNumber;

            InitBoard();

            PopulateBoard();
        }

        public int Length
        {
            get { return _cells.Length; }
        }

        private void InitBoard()
        {
            _cells = new Figures[RowsNumber][];
            for (var i = 0; i < ColsNumber; i++)
            {
                _cells[i] = new Figures[ColsNumber];
            }
        }

        private void PopulateBoard()
        {
            for (int i = 0; i < RowsNumber; i++)
            {
                for (int j = 0; j < ColsNumber; j++)
                {
                    _cells[i][j] = Figures.None;
                }
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

        public void PrintBoard()
        {
            for (int i = 0; i < RowsNumber; i++)
            {
                for (int j = 0; j < ColsNumber; j++)
                {
                    switch (_cells[i][j])
                    {
                        case Figures.None:
                            Console.Write("| |");
                            break;
                        case Figures.X:
                            Console.Write("|X|");
                            break;
                        case Figures.O:
                            Console.Write("|0|");
                            break;
                    }
                    Console.Write(" ");
                }
                Console.WriteLine(Environment.NewLine);
            }
        }

        public bool SetFigure(Move move, Figures figure)
        {
            if (move.X >= 0 && move.X < RowsNumber && move.Y >= 0 && move.Y < ColsNumber)
            {
                if (_cells[move.X][move.Y] != Figures.None)
                {
                    return false;
                }

                _cells[move.X][move.Y] = figure;

                return true;
            }

            return false;
        }

        internal bool IsEmpty(Move move)
        {
            if (move.X < 0 || move.X >= RowsNumber || move.Y < 0 || move.Y >= ColsNumber)
            {
                return false;
            }

            return _cells[move.X][move.Y] == Figures.None;
        }

        internal bool HasEmptyCells()
        {
            for (int i = 0; i < RowsNumber; i++)
            {
                for (int j = 0; j < ColsNumber; j++)
                {
                    if (_cells[i][j] == Figures.None)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Figures GetFigure(int index, int dynamcIndex, Check check)
        {
            if (check == Check.Row)
            {
                return _cells[index][dynamcIndex];
            }
            if (check == Check.Column)
            {
                return _cells[dynamcIndex][index];
            }
            if (check == Check.Diagonal)
            {
                return _cells[dynamcIndex][dynamcIndex];
            }
            if (check == Check.ReverseDiagonal)
            {
                return _cells[Length - 1 - dynamcIndex][dynamcIndex];
            }

            return Figures.None;
        }
    }
}