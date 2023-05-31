namespace TASK3
{
    public class GameRules
    {
        private readonly string[] _moves;
        public string[][] Rules { get; private set; }

        public GameRules(string[] moves)
        {
            _moves = moves;
            Rules = GenerateRules();
        }

        public string GetResult(string userMove, string computerMove)
        {
            int userIndex = Array.IndexOf(_moves, userMove);
            int computerIndex = Array.IndexOf(_moves, computerMove);
            return Rules[userIndex][computerIndex];
        }

        private string[][] GenerateRules()
        {
            int numMoves = _moves.Length;
            string[][] table = new string[numMoves][];

            for (int i = 0; i < numMoves; i++)
            {
                table[i] = new string[numMoves];
                table[i][i] = "Draw";
            }

            for (int i = 0; i < numMoves; i++)
            {
                int half = numMoves / 2;
                for (int j = 1; j <= half; j++)
                {
                    table[i][(i + j) % numMoves] = "Win";
                    table[i][(i - j + numMoves) % numMoves] = "Lose";
                }
            }

            return table;
        }
    }
}
