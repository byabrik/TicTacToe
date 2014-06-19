using System;

namespace TicTacToe
{
    public class ConsoleInputOutput : IInputOutput
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void NewLine()
        {
            Console.WriteLine(System.Environment.NewLine);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}