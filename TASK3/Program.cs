namespace TASK3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] moves = args.Select(x => x.ToString()).ToArray();

            int numMoves = moves.Length;
            if (numMoves < 3 || numMoves % 2 == 0)
            {
                Console.WriteLine("Error: Number of moves should be an odd integer greater than or equal to 3.");
                return;
            }

            GameRules gameRules = new(moves);
            CryptoHelper cryptoHelper = new();

            byte[] key = cryptoHelper.GenerateKey();

            string computerMove = moves[new Random().Next(numMoves)];
            string hmacDigest = cryptoHelper.GenerateHMAC(key, computerMove);
            Console.WriteLine($"HMAC: {hmacDigest}");

            while (true)
            {
                Menu menu = new(moves);
                menu.PrintMenu();

                int userChoice = menu.GetUserChoice();

                switch (userChoice)
                {
                    case -1:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                    case -2:
                        Console.WriteLine("Help table:");
                        TableGenerator.GenerateHelpTable(moves, gameRules.Rules);
                        continue;
                    case 0:
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        string userMove = moves[userChoice - 1];
                        string result = gameRules.GetResult(userMove, computerMove);
                        Console.WriteLine($"\nYour move: {userMove}");
                        Console.WriteLine($"Computer's move: {computerMove}");
                        Console.WriteLine($"Result: {result}");
                        Console.WriteLine($"Key: {BitConverter.ToString(key).Replace("-", "")}");
                        break;
                }
            }
        }
    }
}