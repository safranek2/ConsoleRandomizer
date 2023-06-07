using System;

namespace ConsoleRandomizer
{
    internal class DateGenerator
    {
        private Random random = new Random();

        private ErrorController errorController = new ErrorController();

        public DateGenerator()
        {
        }

        // Display the date generator menu and handle user input
        public void Display()
        {
            DateTime firstDate;
            DateTime lastDate;

            // Prompt the user to enter the first date
            while (true)
            {
                Console.Write("Enter the first date in d.m.yyyy format or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (answer.Equals("exit"))
                {
                    return;
                }

                // Try parsing the user input as a DateTime
                if (DateTime.TryParse(answer, out firstDate))
                {
                    break;
                }
                else
                {
                    errorController.PrintError("You have not entered a valid date!");
                }
            }

            // Prompt the user to enter the last date
            while (true)
            {
                Console.Write("Enter the last date in d.m.yyyy format or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (answer.Equals("exit"))
                {
                    return;
                }

                // Try parsing the user input as a DateTime
                if (DateTime.TryParse(answer, out lastDate))
                {
                    // Check if the last date is later than the first date
                    if (firstDate >= lastDate)
                    {
                        errorController.PrintError("The last date must be later than the first date!");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    errorController.PrintError("You have not entered a valid date!");
                }
            }

            GenerateDate(firstDate, lastDate);
        }

        // Generate a random date between the two dates
        public void GenerateDate(DateTime firstDate, DateTime lastDate)
        {
            // Calculate the number of days between the two dates
            TimeSpan timeSpan = lastDate - firstDate;
            int daysBetween = (int)timeSpan.TotalDays;

            // Generate a random number of days between the two dates and add it to the first date
            DateTime randomDate = firstDate.AddDays(random.Next(daysBetween + 1));

            // Print the randomly generated date in the "d.M.yyyy" format
            Console.WriteLine("Random date: " + randomDate.ToString("d.M.yyyy"));
        }
    }
}
