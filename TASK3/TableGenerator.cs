using Spectre.Console;

namespace TASK3
{
    public class TableGenerator
    {
        public static void GenerateHelpTable(string[] moves, string[][] rules)
        {
            var grid = new Grid();

            grid.AddColumn();

            for(var i = 0; i < moves.Length; i++)
            {
                grid.AddColumn();
            }

            string[] newMoves = new string[moves.Length + 1];
            Array.Copy(moves, 0, newMoves, 1, moves.Length);
            newMoves[0] = "User|PC";

            grid.AddRow(newMoves);

            for (int i = 0; i < moves.Length; i++)
            {
                var row = new string[moves.Length + 1];
                row[0] = moves[i];

                for (int j = 0; j < moves.Length; j++)
                {
                    row[j + 1] = rules[i][j];
                }
                grid.AddRow(row);
            }

            Console.WriteLine();
            AnsiConsole.Render(grid);
            Console.WriteLine();
        }
    }
}
