using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    internal class NumbersGenerator
    {

        private Random random = new Random();

        private ErrorController errorController = new ErrorController();

        private int maxNumbers = 100;

        public NumbersGenerator()
        {
        }

        // Display the numbers generator menu and handle user input
        public void Display()
        {
            int count;
            int min;
            int max;
            bool repetitions = false;

            while (true)
            {
                Console.Write("Enter a number of numbers from 1 to 100 or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (Int32.TryParse(answer, out count))
                {
                    if (count > 0 && count <= maxNumbers)
                    {
                        break;
                    }
                    else
                    {
                        errorController.PrintError("You entered a number outside the range of 1-" + maxNumbers + "!");
                    }
                }
                else if (answer.Equals("exit"))
                {
                    return;
                }
                else
                {
                    errorController.PrintError("You didn't write a number!");
                }
            }

            if (count > 1)
            {
                while (true)
                {
                    Console.Write("Enter 1 if you want the number to be repeated or 'exit' to return to the menu: ");
                    string answer = Console.ReadLine();

                    if (answer.Equals("1"))
                    {
                        repetitions = true;
                        break;
                    }
                    else if (answer.Equals("exit"))
                    {
                        return;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            while (true)
            {
                Console.Write("Enter a minimum number or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (Int32.TryParse(answer, out min))
                {
                    break;
                }
                else if (answer.Equals("exit"))
                {
                    return;
                }
                else
                {
                    errorController.PrintError("You didn't write a number!");
                }
            }

            while (true)
            {
                Console.Write("Enter a maximum number or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (Int32.TryParse(answer, out max))
                {
                    if (!repetitions && max >= min + count - 1)
                    {
                        break;
                    }
                    else if (!repetitions)
                    {
                        errorController.PrintError("Max number must be a larger or equal number than minimum number plus number of numbers!");
                    }
                    else if (max > min)
                    {
                        break;
                    }
                    else
                    {
                        errorController.PrintError("Max number must be a larger number than minimum number!");
                    }
                }
                else if (answer.Equals("exit"))
                {
                    return;
                }
                else
                {
                    errorController.PrintError("You didn't write a number!");
                }
            }

            GenerateNumbers(count, min, max, repetitions);
        }

        // Generates and prints random numbers based on the provided inputs.
        public void GenerateNumbers(int count, int min, int max, bool repetitions)
        {
            List<int> numbers = new List<int>();

            for (int i = 1; i <= count; i++)
            {
                int number = random.Next(min, max + 1);

                // If repetitions are not allowed and the number is already generated, regenerate a new number.
                while (!repetitions && numbers.Contains(number))
                {
                    number = random.Next(min, max + 1);
                }

                Console.WriteLine(i + ") " + number);
                numbers.Add(number);
            }
        }
    }
}