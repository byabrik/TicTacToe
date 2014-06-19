namespace TicTacToe
{
    public sealed class Player
    {       
        public Player(Figures figure, string name)
        {
            _figure = figure;
            Name = name;
        }
        
        public string Name { get; private set; }

        public bool MakeMove(Board board, Move move)
        {
            return board.SetFigure(move, _figure);
        }

        private readonly Figures _figure;
    }
}