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
            var game = new Game(3,3, new ConsoleInputOutput(), null);

            game.StartGame();

            Console.Read();
        }
    }
}
