using System;

namespace ConsoleRandomizer
{
    internal class TimeGenerator
    {
        private Random random = new Random();

        private ErrorController errorController = new ErrorController();

        public TimeGenerator()
        {
        }

        // Display the time generator menu and handle user input
        public void Display()
        {
            DateTime firstTime;
            DateTime lastTime;

            while (true)
            {
                Console.Write("Enter the first time in H:mm format or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (DateTime.TryParseExact(answer, "H:mm", null, System.Globalization.DateTimeStyles.None, out firstTime))
                {
                    break;
                }
                else if (answer.Equals("exit"))
                {
                    return;
                }
                else
                {
                    errorController.PrintError("You have not entered a time or entered an invalid time!");
                }
            }

            while (true)
            {
                Console.Write("Enter the last time in H:mm format or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (DateTime.TryParseExact(answer, "H:mm", null, System.Globalization.DateTimeStyles.None, out lastTime))
                {
                    if (firstTime >= lastTime)
                    {
                        errorController.PrintError("The last time must be later than the first time!");
                    }
                    else
                    {
                        break;
                    }
                }
                else if (answer.Equals("exit"))
                {
                    return;
                }
                else
                {
                    errorController.PrintError("You have not entered a time or entered an invalid time!");
                }
            }

            GenerateTime(firstTime, lastTime);
        }

        // Generate a random time between the first and last time
        public void GenerateTime(DateTime firstTime, DateTime lastTime)
        {
            // Calculate the number of minutes between the two dates
            TimeSpan timeSpan = lastTime - firstTime;
            int minutes = (int)timeSpan.TotalMinutes;

            // Generate a random time within the given range
            DateTime randomTime = firstTime.AddMinutes(random.Next(minutes + 1));

            // Print the generated time in the required format
            Console.WriteLine(randomTime.ToString("H:mm"));
        }
    }
}
