namespace TicTacToe
{
    public interface IInputOutput
    {
        void Write(string message);
        void WriteLine(string message);
        void NewLine();
        string Read();
    }
}