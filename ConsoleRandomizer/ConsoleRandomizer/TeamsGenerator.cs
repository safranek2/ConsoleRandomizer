using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    internal class TeamsGenerator
    {
        private Random random = new Random();

        private ErrorController errorController = new ErrorController();

        private int minTeams = 2;
        private int maxTeams = 12;

        public TeamsGenerator()
        {
        }

        // Display the teams generator menu and handle user input
        public void Display()
        {
            List<string> names = new List<string>();
            bool enabled = false;

            while (true)
            {
                if (!enabled)
                {
                    Console.WriteLine("1) Add name\n0) Exit");
                }
                else
                {
                    Console.WriteLine("1) Add name\n2) Create teams\n0) Exit");
                }

                Console.Write("Enter your choice: ");
                string answer = Console.ReadLine();

                if (Int32.TryParse(answer, out int intAnswer))
                {
                    if (intAnswer == 1)
                    {
                        AddName(names);
                        if (!enabled && names.Count > 1)
                        {
                            enabled = true;
                        }
                    }
                    else if (intAnswer == 2 && enabled)
                    {
                        break;
                    }
                    else if (intAnswer == 0)
                    {
                        return;
                    }
                    else
                    {
                        errorController.PrintError("You entered an invalid number!");
                    }
                }
                else
                {
                    errorController.PrintError("You didn't enter a number!");
                }
            }

            int count;

            while (true)
            {
                Console.Write("Enter the number of teams from " + minTeams + " to " + maxTeams + " or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (Int32.TryParse(answer, out count))
                {
                    if (count >= names.Count)
                    {
                        errorController.PrintError("The number of teams must be greater than or equal to the number of names!");
                    }
                    else if (count >= minTeams && count <= maxTeams)
                    {
                        break;
                    }
                    else
                    {
                        errorController.PrintError("You entered a number outside the range of " + minTeams + " - " + maxTeams + "!");
                    }
                }
                else if (answer.Equals("exit"))
                {
                    return;
                }
                else
                {
                    errorController.PrintError("You didn't enter a number!");
                }
            }

            CreateTeams(names, count);
        }

        // Add a name to the list of names
        private void AddName(List<string> names)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            names.Add(name);
        }

        // Create teams by distributing names among them
        private void CreateTeams(List<string> names, int count)
        {
            int numberOfNamesInTeam = names.Count / count;

            for (int i = 1; i < count; i++)
            {
                List<string> team = new List<string>();
                for (int x = 0; x < numberOfNamesInTeam; x++)
                {
                    int index = random.Next(0, names.Count);
                    team.Add(names[index]);
                    names.RemoveAt(index);
                }
                Console.Write("Team " + i + ": ");
                WriteTeam(team);
            }

            Console.Write("Team " + count + ": ");
            WriteTeam(names);
        }

        // Write the names of the team members separated by commas
        private void WriteTeam(List<string> team)
        {
            for (int i = 0; i < team.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(team[i]);
                }
                else
                {
                    Console.Write(", " + team[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
