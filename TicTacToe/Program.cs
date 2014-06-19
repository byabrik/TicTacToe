using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(4,4, new ConsoleInputOutput());

            game.StartGame();

            Console.Read();
        }
    }
}
