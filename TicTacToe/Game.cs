using System;

namespace TicTacToe
{
    public class Game
    {
        private readonly Board _board;
        private readonly IInputOutput _inputOutput;
        private readonly Player _player1;
        private readonly Player _player2;
        private Player _currentPlayer;
        private Player _winner;

        public Game(int rowsNumber, int colsNumber, IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
            _board = new Board(rowsNumber, colsNumber);
            _player1 = new Player(Figures.X, "Player1");
            _player2 = new Player(Figures.O, "Player2");
            _currentPlayer = _player2;
        }

        public int GameOver()
        {
            if (HasWon() != Figures.None)
            {
                _winner = _currentPlayer;
                return 1;
            }

            if (!_board.HasEmptyCells())
            {
                return 0;
            }

            return -1;
        }

        public bool IsValidMove(Move move)
        {
            return _board.IsEmpty(move);
        }


        public void StartGame()
        {
            while (GameOver() == -1)
            {
                _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;

                _board.PrintBoard();

                var move = GetUserInput();

                _currentPlayer.MakeMove(_board, move);

                _inputOutput.WriteLine(Environment.NewLine);
            }

            if (_winner == null)
            {
                _inputOutput.WriteLine("Teko!");
            }
            else
            {
                _inputOutput.WriteLine(string.Format("Congratulations {0}, you won!", _winner.Name));
            }
        }

        private Move GetUserInput()
        {
            _inputOutput.WriteLine(Environment.NewLine);
            _inputOutput.WriteLine(_currentPlayer.Name + " move:");

            bool flag = false;
            int inputX = -1;
            int inputY = -1;

            while (!flag)
            {
                _inputOutput.WriteLine("Enter x coordinate:");
                string strX = _inputOutput.Read();
                _inputOutput.WriteLine("Enter y coordinate:");
                string strY = _inputOutput.Read();

                bool xResult = int.TryParse(strX, out inputX);

                if (!xResult || (xResult && (inputX < 0 || inputX >= _board.RowsNumber)))
                {
                    _inputOutput.WriteLine("incorrect x input");
                    _board.PrintBoard();
                    continue;
                }

                bool yResult = int.TryParse(strY, out inputY);

                if (!yResult || (yResult && (inputY < 0 || inputY >= _board.ColsNumber)))
                {
                    _inputOutput.WriteLine("incorrect y input");
                    _board.PrintBoard();
                    continue;
                }

                if (!IsValidMove(new Move(inputX, inputY)))
                {
                    _inputOutput.WriteLine("Incorrect move, please try again");
                    _board.PrintBoard();
                    continue;
                }

                flag = true;
            }

            return new Move(inputX, inputY);
        }

        private Figures HasWon()
        {
            int N = _board.Length;

            var winner = Figures.None;

            // Check rows and columns
            for (int i = 0; i < N; i++)
            {
                winner = GetWinner(i, Check.Row);
                if (winner != Figures.None)
                {
                    return winner;
                }

                winner = GetWinner(i, Check.Column);
                if (winner != Figures.None)
                {
                    return winner;
                }
            }

            winner = GetWinner(-1, Check.Diagonal);
            if (winner != Figures.None)
            {
                return winner;
            }

            // Check diagonal
            winner = GetWinner(-1, Check.ReverseDiagonal);
            if (winner != Figures.None)
            {
                return winner;
            }

            return winner;
        }

        private Figures GetWinner(int fixedIndex, Check check)
        {
            Figures figure = _board.GetFigure(fixedIndex, 0, check);
            if (figure == Figures.None)
            {
                return figure;
            }

            //check the rest
            for (int dynamcIndex = 1; dynamcIndex < _board.Length; dynamcIndex++)
            {
                if (figure != _board.GetFigure(fixedIndex, dynamcIndex, check))
                {
                    return Figures.None;
                }
            }

            return figure;
        }
    }
}