using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    internal class ListGenerator
    {
        private Random random = new Random();

        private ErrorController errorController = new ErrorController();

        public ListGenerator()
        {
        }

        // Display the list generator menu and handle user input
        public void Display()
        {
            List<string> list = new List<string>();
            bool enabled = false;

            while (true)
            {
                // Display the menu options based on whether the list is enabled or not
                if (!enabled)
                {
                    Console.WriteLine("1) Add name\n0) Exit");
                }
                else
                {
                    Console.WriteLine("1) Add name\n2) Shuffle List\n3) Pick One!\n0) Exit");
                }

                Console.Write("Enter your choice: ");
                string answer = Console.ReadLine();

                if (Int32.TryParse(answer, out int intAnswer))
                {
                    if (intAnswer == 1)
                    {
                        AddName(list);
                        if (!enabled && list.Count > 1)
                        {
                            enabled = true;
                        }
                    }
                    else if (intAnswer == 2 && enabled)
                    {
                        ShuffleList(list);
                        break;
                    }
                    else if (intAnswer == 3 && enabled)
                    {
                        string name = list[random.Next(0, list.Count)];
                        Console.WriteLine("I pick: " + name);
                        break;
                    }
                    else if (intAnswer == 0)
                    {
                        return;
                    }
                    else
                    {
                        errorController.PrintError("You entered an incorrect number!");
                    }
                }
                else
                {
                    errorController.PrintError("You did not enter a number!");
                }
            }
        }

        // Add a name to the list
        public void AddName(List<string> list)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            list.Add(name);
        }

        // Shuffle the list
        public void ShuffleList(List<string> list)
        {
            List<string> newList = new List<string>();

            while (list.Count > 0)
            {
                int index = random.Next(0, list.Count);
                newList.Add(list[index]);
                list.RemoveAt(index);
            }

            WriteList(newList);
        }

        // Write the content of the list to the console
        public void WriteList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write("Results: " + list[i]);
                }
                else
                {
                    Console.Write(", " + list[i]);
                }
            }
        }
    }
}
