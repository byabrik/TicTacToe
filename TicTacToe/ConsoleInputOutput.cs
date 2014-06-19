using System;
using System.Threading.Tasks;

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

        public void AnnounceTheWinner(string winnerName)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(string.Format("Congratulations {0}, you won!", winnerName));
        }

        public void ShowBoard(Figures[][] cells)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                for (int j = 0; j < cells[i].Length; j++)
                {
                    switch (cells[i][j])
                    {
                        case Figures.None:
                            Console.Write("| |");
                            break;
                        case Figures.X:
                            Console.Write("|X|");
                            break;
                        case Figures.O:
                            Console.Write("|0|");
                            break;
                    }
                    Console.Write(" ");
                }
                Console.WriteLine(Environment.NewLine);
            }
        }

        public void AnnounceTeko()
        {
            Console.WriteLine("Teko!");
        }

        public Move GetUserInput(Player currentPlayer, Figures[][] cells, Func<Move,bool> isValidMove)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(currentPlayer.Name + " move:");

            var flag = false;
            var inputX = -1;
            var inputY = -1;

            while (!flag)
            {
                Console.WriteLine("Enter x coordinate (from 1 to 3):");
                string strX = Console.ReadLine();

                Console.WriteLine("Enter y coordinate (from 1 to 3):");
                string strY = Console.ReadLine();

                if ((inputX = GetCoordinate(strX, cells.Length + 1, 1, "x", cells)) == -1)
                {
                    continue;
                }

                if ((inputY = GetCoordinate(strY, cells[0].Length + 1, 1, "y", cells)) == -1)
                {
                    continue;
                }

                if (!isValidMove(new Move(inputX - 1, inputY - 1, currentPlayer.Figure)))
                {
                    Console.WriteLine("Incorrect move, please try again");
                    ShowBoard(cells);
                    continue;
                }

                flag = true;
            }

            return new Move(inputX - 1, inputY - 1, currentPlayer.Figure);
        }

        public int GetCoordinate(string str, int max, int min, string coordinateName, Figures[][] cells)
        {
            int input;

            bool result = int.TryParse(str, out input);

            if (!result || (result && (input < min || input >= max)))
            {
                Console.WriteLine(string.Format("incorrect {0} input", coordinateName));
                ShowBoard(cells);
                return -1;
            }

            return input;
        }
    }
}