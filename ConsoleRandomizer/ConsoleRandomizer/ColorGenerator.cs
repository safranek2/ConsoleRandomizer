using ConsoleRandomizer.vendor;  // Importing the vendor namespace for ClosestConsoleColor
using System;

namespace ConsoleRandomizer
{
    internal class ColorGenerator
    {
        private Random random = new Random();

        private ClosestConsoleColor closestConsoleColor = new ClosestConsoleColor();

        public ColorGenerator()
        {
        }

        public void Display()
        {
            // Generate a random color in hexadecimal format
            string color = GenerateRandomColor();

            // Calculate the closest console color to the generated color
            ConsoleColor closestColor = closestConsoleColor.Calculate(color);

            // Display the generated color
            Console.WriteLine("Random Color:");
            Console.Write(color);

            // Display the closest console color
            Console.Write("Closest Console Color:");
            SetConsoleBackgroundColor(closestColor);
            Console.WriteLine($"The closest console color to " + color + " is " + closestColor.ToString());
            ResetConsoleBackgroundColor();
        }

        // Generate a random color in hexadecimal format
        private string GenerateRandomColor()
        {
            // Generate random values for each color channel (RGB)
            int red = random.Next(256);
            int green = random.Next(256);
            int blue = random.Next(256);

            // Format the values as a hexadecimal color code
            string color = $"#" + red.ToString("X2") + green.ToString("X2") + blue.ToString("X2");

            return color;
        }

        // Set the console background color
        private void SetConsoleBackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        // Reset the console background color to black
        private void ResetConsoleBackgroundColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
