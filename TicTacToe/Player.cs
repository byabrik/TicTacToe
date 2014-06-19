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
            return board.SetFigure(move);
        }

        private readonly Figures _figure;

        public Figures Figure
        {
            get { return _figure; }
        }
    }
}