namespace TASK3
{
    public class Menu
    {
        private readonly string[] _moves;

        public Menu(string[] moves)
        {
            _moves = moves;
        }

        public void PrintMenu()
        {
            Console.WriteLine("Select your move:");
            for (int i = 0; i < _moves.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {_moves[i]}");
            }
            Console.WriteLine("0 - Exit");
            Console.WriteLine("? - help");
        }
        public int GetUserChoice()
        {
            string UserChoice = Console.ReadLine();

            if (UserChoice == "?")
            {
                return -2;
            }

            if (int.TryParse(UserChoice, out int choice) && choice >= 0 && choice <= _moves.Length)
            {
                return choice;
            }

            return -1;
        }
    }
}
