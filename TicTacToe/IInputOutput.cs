using System;

namespace TicTacToe
{
    public interface IInputOutput
    {
        void Write(string message);
        
        void WriteLine(string message);
        
        void NewLine();
        
        string Read();

        void AnnounceTheWinner(string winnerName);

        void ShowBoard(Figures[][] cells);

        void AnnounceTeko();
        Move GetUserInput(Player currentPlayer, Figures[][] cells, Func<Move, bool> isValidMove);
    }
}