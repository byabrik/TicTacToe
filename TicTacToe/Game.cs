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
        private enum GameState
        {
            InProgress,
            Teko,
            HasWinner
        }

        public Game(int rowsNumber, int colsNumber, IInputOutput inputOutput, Figures[][] boardFigures)
        {
            _inputOutput = inputOutput;
            _board = new Board(rowsNumber, colsNumber, boardFigures);
            _player1 = new Player(Figures.X, "Player1");
            _player2 = new Player(Figures.O, "Player2");
            _currentPlayer = _player1;
        }

        public bool IsValidMove(Move move)
        {
            return _board.IsEmpty(move);
        }

        public void StartGame()
        {
            while (GameOver() == GameState.InProgress)
            {
                _inputOutput.ShowBoard(_board.GetCells());

                var move = _inputOutput.GetUserInput(_currentPlayer, _board.GetCells(), IsValidMove);

                _currentPlayer.MakeMove(_board, move);

                SwitchPlayers();
            }

            if (_winner == null)
            {
                _inputOutput.AnnounceTeko();
            }
            else
            {
                _inputOutput.ShowBoard(_board.GetCells());
                _inputOutput.AnnounceTheWinner(_winner.Name);
            }
        }

        private void SwitchPlayers()
        {
            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
        }

        private GameState GameOver()
        {
            if (HasWon() != Figures.None)
            {
                _winner = _currentPlayer == _player1 ? _player2 : _player1;
                
                return GameState.HasWinner;
            }

            if (!_board.HasEmptyCells())
            {
                return GameState.Teko;
            }

            return GameState.InProgress;
        }

        private Figures HasWon()
        {
            int n = _board.Length;

            var winner = Figures.None;

            // Check rows and columns
            for (int i = 0; i < n; i++)
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