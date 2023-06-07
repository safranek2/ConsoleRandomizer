using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    internal class OptionsGenerator
    {
        private Random random = new Random();

        public OptionsGenerator()
        {
        }

        // Display a random option from the given list.
        public void Display(List<string> list)
        {
            // Generate a random index within the range of the options list.
            int randomIndex = random.Next(0, list.Count);

            // Display the random option to the console.
            Console.WriteLine("It is: " + list[random.Next(randomIndex)]);
        }
    }
}
