using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public sealed class Move
    {
        public Move(int x, int y, Figures figure)
        {
            X = x;
            Y = y;
            Figure = figure;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        public Figures Figure { get; set; }
    }
}
