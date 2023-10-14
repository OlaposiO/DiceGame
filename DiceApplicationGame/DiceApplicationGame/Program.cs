namespace DiceApplicationGame
{
    class Program
    {
        static Random randomNum = new Random();

        static void Main(string[] args)
        {
            bool continueR;

            do
            {
                Console.WriteLine("Enter the num of sides for a pair of dice");
                int sides = GetValidInput();

                int firstRoll = RollDice(sides);
                int secondRoll = RollDice(sides);
                int total = firstRoll + secondRoll;

                Console.WriteLine($"Your total is: {total}! You roll a {firstRoll} & a {secondRoll}");

                string combinationMessage = GetComboMessage(firstRoll, secondRoll);
                string totalMessgae = GetTotalMessage(total);

                if (!string.IsNullOrEmpty(GetComboMessage(firstRoll, secondRoll)))
                {
                    Console.WriteLine(combinationMessage);
                };
                if (!string.IsNullOrEmpty(GetTotalMessage(total)))
                {
                    Console.WriteLine(totalMessgae);
                };

                Console.WriteLine("Roll again? (yes/no)");
                string playAgain = Console.ReadLine().ToLower();
                continueR = playAgain == "yes";
            } while (continueR);
        }

        static int GetValidInput()
        {
            int sides;
            while (!int.TryParse(Console.ReadLine(), out sides) || sides < 2)
            {
                Console.WriteLine("please put in a number larger than 2.");
            }
            return sides;
        }

        static int RollDice(int sides)
        {
            return randomNum.Next(1, sides + 1);
        }

        static string GetComboMessage(int roll1, int roll2)
        {
            if (roll1 == 1 && roll2 == 1)
            {
                return "snake eye";
            }
            else if ((roll1 == 1 && roll2 == 2) || (roll1 == 2 && roll2 == 1))
            {
                return "Ace Deuce";
            }
            else if (roll1 == 6 && roll2 == 6)
            {
                return "Box Cars";
            }
            else
            {
                return "";
            }

        }

        static string GetTotalMessage(int total)
        {
            if (total == 7 || total == 11)
            {
                return "Win";
            }
            else if (total == 2 || total == 3 || total == 12)
            {
                return "Craps";
            }
            else
            {
                return "";

            }
        }
    }
}
