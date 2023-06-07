using System;

namespace ConsoleRandomizer
{
    internal class DiceRoll
    {
        private Random random = new Random();

        private ErrorController errorController = new ErrorController();

        private int minDice = 1;
        private int maxDice = 10;
        private int minSides = 3;
        private int maxSides = 100;

        public DiceRoll()
        {
        }

        // Display the dice roll menu and handle user input
        public void Display()
        {
            int count = 0;
            int sides = 0;

            // Prompt the user to enter the number of dice
            while (true)
            {
                Console.Write("Enter the number of dice (" + minDice + "-" + maxDice + ") or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (answer.Equals("exit"))
                {
                    return;
                }

                if (Int32.TryParse(answer, out count))
                {
                    if (count >= minDice && count <= maxDice)
                    {
                        break;
                    }
                    else
                    {
                        errorController.PrintError("You entered a number outside the range of " + minDice + "-" + maxDice + "!");
                    }
                }
                else
                {
                    errorController.PrintError("You did not enter a valid number!");
                }
            }

            // Prompt the user to enter the number of sides on each die
            while (true)
            {
                Console.Write("Enter the number of sides on each die (" + minSides + "-" + maxSides + ") or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (answer.Equals("exit"))
                {
                    return;
                }

                if (Int32.TryParse(answer, out sides))
                {
                    if (sides >= minSides && sides <= maxSides)
                    {
                        break;
                    }
                    else
                    {
                        errorController.PrintError("You entered a number outside the range of " + minSides + "-" + maxSides + "!");
                    }
                }
                else
                {
                    errorController.PrintError("You did not enter a valid number!");
                }
            }

            GenerateDices(count, sides);
        }

        // Generate and display the dice rolls
        public void GenerateDices(int count, int sides)
        {
            int results = 0;

            Console.Write("Rolled dices: ");

            for (int i = 0; i < count; i++)
            {
                // Roll if the dice
                int number = random.Next(1, sides + 1);
                results += number;

                // Display the result of each die roll
                if (i == 0)
                {
                    Console.Write(number);
                }
                else
                    Console.Write(" + " + number);
            }

            // Display the total sum of all dice rolls
            Console.WriteLine(" = " + results);
        }
    }
}
